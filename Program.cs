using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Menu
{
    class Program
    {
        class Burger
        {
            string bread;
            string sauce;
            string cheese;
            public Burger() { }
            public void SetBread(string b) { bread = b; }
            public void SetSauce(string s) { sauce = s; }
            public void SetAddCheese(string c) { cheese = c; }
            public void Info()
            {
                Console.WriteLine("bread: {0}\nSause: {1}\nCheese: {2}",
               bread, sauce, cheese);
            }
        }
        abstract class BurgerCraft
        {
            protected Burger burger;
            public BurgerCraft() { }
            public Burger GetBurger() { return burger; }
            public void CreateNewBurger() { burger = new Burger(); }
            public abstract void BuildBread();
            public abstract void BuildSauce();
            public abstract void BuildCheese();
        }
        class BeafBurgerBuilder : BurgerCraft
        {
            public override void BuildBread() { burger.SetBread("white"); }
            public override void BuildSauce() { burger.SetSauce("BBQ"); }
            public override void BuildCheese()
            {
                burger.SetAddCheese("yes");
            }
        }
        class SpicyBurgerBuilder : BurgerCraft
        {
            public override void BuildBread()
            {
                burger.SetBread("white");
            }
            public override void BuildSauce() { burger.SetSauce("hot"); }
            public override void BuildCheese()
            {
                burger.SetAddCheese("yes");
            }
        }
        class ChickenBurgerBuilder : BurgerCraft
        {
            public override void BuildBread() { burger.SetBread("black"); }
            public override void BuildSauce() { burger.SetSauce("Ketchup"); }
            public override void BuildCheese()
            {
                burger.SetAddCheese("no");
            }
        }
        class Waiter
        {
            private BurgerCraft burgercraft;
            public void SetBurgerCraft(BurgerCraft pb)
            {
                burgercraft = pb;
            }
            public Burger GetBurger() { return burgercraft.GetBurger(); }
            public void ConstructPizza()
            {
                burgercraft.CreateNewBurger();
                burgercraft.BuildBread();
                burgercraft.BuildSauce();
                burgercraft.BuildCheese();
            }
        }
        class Builder
        {
            public static void Main(String[] args)
            {
                Waiter waiter = new Waiter();
                BurgerCraft beafBurgerBuilder = new BeafBurgerBuilder();
                BurgerCraft spicyPizzaBuilder = new SpicyBurgerBuilder();
                BurgerCraft chickenBurgerBuilder = new ChickenBurgerBuilder();
                waiter.SetBurgerCraft(beafBurgerBuilder);
                waiter.ConstructPizza();
                Burger burger = waiter.GetBurger();
                burger.Info();
                waiter.SetBurgerCraft(chickenBurgerBuilder);
                waiter.ConstructPizza();
                burger = waiter.GetBurger();
                burger.Info();
                Console.ReadKey();
            }
        }
    }
}
