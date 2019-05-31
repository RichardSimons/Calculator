using System;
using System.Reflection.Metadata.Ecma335;
using CalculatorConsole;
using Xunit;

namespace Calculator.Text
{
  public class Calculator
  {
    
    /// Sample product: Book with name = “The Little Prince”, UPC=12345, price=$20.25.
    
    [Theory]
    [InlineData(20.25,24.30,20)]
    [InlineData(20.25, 24.50, 21)]
    public void calc_ShouldReturnCorrectTaxPrice(double priceBase, double afterTax, double taxRate)
    {
      Product testProduct = new Product("The Little Prince", 12345, priceBase, taxRate);
      
      var totalPrice = testProduct.PriceWithTaxs();
      Assert.Equal( afterTax,totalPrice);
    }


    [Theory]
    [InlineData(20.25, 24.30, 20)]
    [InlineData(20.25, 24.50, 21)]
    public void calculate_ReturnsBasePriceAndPriceWithTax_Text(double priceBase, double afterTax, double taxRate)
    {
      var testProduct = new Product("The Little Prince", 12345, priceBase, taxRate);

      Assert.Equal($"Product price reported as ${priceBase} before tax and ${afterTax} after {taxRate}% tax.",
        $"Product price reported as ${testProduct.PriceBase} before tax and ${testProduct.PriceWithTaxs()} after {testProduct.TaxRate}% tax.");
     
    }


    // **Test Case**
    // Definition:
    // Sample product: Book with name = “The Little Prince”, UPC=12345, price=$20.25, Tax=20%, discount=15%
    // Output:
    // "Tax amount = $4.05; Discount amount = $3.04 Price before = $20.25, price after = $21.26"
    // *****************************************************************************************************


    [Theory]
    [InlineData(20.25, 20, 15)]
    public void calculate_Return_TaxAmount_DiscountAmount_PriceBefore_PriceAfter(double priceBase, double taxRate,
      double DiscountRate)
    {
      var testProduct = new Product("The Little Prince", 12345, priceBase, taxRate);
      var discount = new Discount(testProduct,DiscountRate);

      Assert.Equal("Tax amount = $4.05; Discount amount = $3.04 Price before = $20.25, price after = $21.26",
        $"Tax amount = {testProduct.CalcTax():C}; Discount amount = {discount.DiscountAmount():C} Price before = {testProduct.PriceBase:C}, price after = {discount.PriceWithDiscount():C}");

    }


    //  Definition
    //  Sample product: Title = “The Little Prince”, UPC=12345, price=$20.25.

    //  Case #1:

    //  Tax = 20 %, discount = 15 %
    //  Program prints price $21.26
    //  Program displays $3.04 amount which was deduced

    //  Case #2:

    //  Tax = 20 %, no discount
    //  Program prints price $24.30

    [Theory]
    [InlineData(20.25, 20, 15)]
    public void ReportBuilder_TestReportWithDiscount(double priceBase, double taxRate, double DiscountRate)
    {
      Product product = new Product("The Little Prince", 12345, 20.25, taxRate);
      ReportBuilder Report = new ReportBuilder(product, new Discount(product, DiscountRate));

      Assert.Equal("Product: The Little Prince\n" +
                   "UPC: 12345 Price: $21.26\nDiscount: $3.04",Report.GenReport());


    }
    [Theory]
    [InlineData(20.25, 20)]
    public void ReportBuilder_TestReportWithOutDiscount(double priceBase, double taxRate)
    {
      Product product = new Product("The Little Prince", 12345, 20.25, taxRate);
      ReportBuilder Report = new ReportBuilder(product);

      Assert.Equal("Product: The Little Prince\n" +
                   "UPC: 12345 Price: $24.30\n", Report.GenReport());


    }
  }
}
