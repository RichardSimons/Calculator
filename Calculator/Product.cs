using System;
using System.Collections.Generic;
using System.Text;


namespace Calculator
{
  public class Product
  {
    public string Name { get; set; }
    public int Upc { get; set; }
    public double PriceBase { get; set; }
    public double TaxRate { get; set; }
    
    public Product(string name, int upc, double priceBase, double taxRate)
    {
      Name = name;
      Upc = upc;
      PriceBase = priceBase;
      TaxRate = taxRate;
    }
    public double CalcTax()
    {
      return PriceBase * (TaxRate/100);
    }
    public double PriceWithTaxs()
    {
      return Math.Round(CalcTax() + PriceBase,2, MidpointRounding.AwayFromZero);
    }

  }
}
