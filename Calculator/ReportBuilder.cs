using System;
using System.Collections.Generic;
using System.Text;
using Calculator;

namespace CalculatorConsole
{
  public class ReportBuilder
  {
    private readonly Discount _discount;
    private readonly Product _product;

    public ReportBuilder(Product product, Discount discount)
    {
      _discount = discount;
      _product = product;
    }
    public ReportBuilder(Product product)
    {
      _product = product;
    }

    public string GenReport()
    {
      string Report;
      if (_discount == null)
      {
        Report = ($"Product: {_product.Name}\n" +
                          $"UPC: {_product.Upc.ToString()} Price: {_product.PriceWithTaxs():C}\n");
      }
      else
      {
        Report = ($"Product: {_product.Name}\n" +
                          $"UPC: {_product.Upc.ToString()} Price: {_discount.PriceWithDiscount():C}\n" +
                          $"Discount: {_discount.DiscountAmount():C}");
      }

      return Report;
    }
  }
}
