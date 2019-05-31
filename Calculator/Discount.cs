using System;
using System.Collections.Generic;
using System.Text;

namespace Calculator
{
  public class Discount
  {
    private readonly Product _product;
    public double RatePercentage { get; set; }
    
    public Discount(Product product, double ratePercentage)
    {
      _product = product;
      RatePercentage = ratePercentage;
    }

    public double DiscountAmount()
    {
      return _product.PriceBase * (RatePercentage / 100);
    }
    public double PriceWithDiscount()
    {
      return _product.PriceWithTaxs() - DiscountAmount();
    }

  }


  

}
