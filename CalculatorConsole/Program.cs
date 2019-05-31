using System;
using System.Dynamic;
using Calculator;

namespace CalculatorConsole
{
  class Program
  {

    //Definition of done:
    //Sample product: Title = “The Little Prince”, UPC=12345, price=$20.25.

    //  Case #1:

    //  Tax = 20 %, discount = 15 %
    //  Program prints price $21.26
    //  Program displays $3.04 amount which was deduced

    //  Case #2:

    //  Tax = 20 %, no discount
    //  Program prints price $24.30

    static void Main(string[] args)
    {

      Product SampleProduct = new Product("The Little Prince",12345,20.25,20);
      Discount SampleDiscount = new Discount(SampleProduct,15);

      
      ReportBuilder priceReport = new ReportBuilder(SampleProduct,SampleDiscount);
      ReportBuilder PriceReportWithOutDiscount = new ReportBuilder(SampleProduct);

      Console.WriteLine(priceReport.GenReport());
      Console.WriteLine(PriceReportWithOutDiscount.GenReport());

      Console.ReadKey();
    }


  }
}
