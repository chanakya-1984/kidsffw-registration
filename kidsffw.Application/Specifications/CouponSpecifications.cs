﻿namespace kidsffw.Application.Specifications;

using Domain.Entity;
using kidsffw.Repository.Implementation.Repository;

public static class Specifications
{
    public static BaseSpecification<CouponEntity> GetCouponCodeByCouponId(string couponCode)
    {
        return new BaseSpecification<CouponEntity>(x => x.CouponCode == couponCode);
    }

    public static BaseSpecification<OtpEntity> VerifyOtp(string mobileNumber, string otpCode, DateTime validationTime)
    {
        return new BaseSpecification<OtpEntity>
        (x =>
            x.Otp == otpCode &&
            x.MobileNumber == mobileNumber &&
            x.ValidTill >= validationTime);
    }

}

