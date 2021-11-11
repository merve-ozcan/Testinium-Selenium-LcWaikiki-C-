using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SeleniumTest
{
    class Test
    {
     
        //create the reference for the browser  
        IWebDriver driver = new ChromeDriver(@"C:\Users\merve\source\repos\SeleniumTest\SeleniumTest\");

        [SetUp]
        public void Initialize()
        {
            Console.Write("Test başlatıldı \n");

            //navigate to URL  
            driver.Navigate().GoToUrl("https://www.lcwaikiki.com/tr-TR/TR");
          
            //Maximize the browser window  
            driver.Manage().Window.Maximize();
            Thread.Sleep(1000);

        }

        [Test]
        public void ExecuteTest()
        {
            IWebElement giris_yap = driver.FindElement(By.LinkText("Giriş Yap"));

            giris_yap.Click();

            Thread.Sleep(1000);

            IWebElement mail = driver.FindElement(By.Id("LoginEmail"));
            mail.SendKeys("mamaymilayk@outlook.com");
            Thread.Sleep(1000);
            Console.Write("mail girildi \n");

            IWebElement password = driver.FindElement(By.Id("Password"));
            password.SendKeys("123456d");
            Console.Write("şifre girildi \n");

            IWebElement giris_btn = driver.FindElement(By.Id("loginLink"));
            giris_btn.Click();
            Thread.Sleep(1000);
            Console.Write("login butonuna tıklandı \n");

            IWebElement search = driver.FindElement(By.Id("search_input"));
            search.Click();
            search.SendKeys("pantolon");
            Thread.Sleep(1000);
            Console.Write("aranılacak kelime girildi \n");

            IWebElement search_btn = driver.FindElement(By.TagName("button"));
            search_btn.Click();
            Thread.Sleep(1000);
            Console.Write("ara butonuna tıklandı \n");

            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("window.scrollTo(0, document.body.scrollHeight)");

            IWebElement urun_gor = driver.FindElement(By.PartialLinkText("Daha Fazla Ürün Gör"));
            urun_gor.Click();
            Thread.Sleep(1000);
            Console.Write("daha fazla ürün gör butonuna tıklandı \n");




            Thread.Sleep(1000);

            IWebElement urunler = driver.FindElement(By.XPath("/html/body/div[5]/div[3]/div[2]/div[7]/div/div[1]"));
            IList<IWebElement> urunler_list = urunler.FindElements(By.TagName("a"));

            Console.Write("toplam ürün: " + urunler_list.Count().ToString());
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Manage().Window.Maximize();
            urunler_list.ElementAt(new Random().Next(0, urunler_list.Count - 1)).Click();

            Thread.Sleep(2000);

            IWebElement beden = driver.FindElement(By.XPath("/html/body/div[5]/div[3]/div[1]/div[2]/div[2]/div[2]/div[1]/div/div[4]/div[1]/div[2]/div/div[1]/div[3]"));



            IList<IWebElement> beden_list = beden.FindElements(By.TagName("a"));
            IList<IWebElement> beden_secilemez = beden.FindElements(By.ClassName("disabled"));

            IList<IWebElement> beden_secilebilir = beden_list.Except(beden_secilemez).ToList();



            Console.Write("toplam beden: " + beden_secilebilir.Count().ToString());


            beden_secilebilir.ElementAt(new Random().Next(0, beden_secilebilir.Count - 1)).Click();

            Thread.Sleep(2000);


            By by = By.CssSelector("div[class='option-height']");
            var element = driver.FindElements(by).Count >= 1 ? driver.FindElement(by) : null;

            if (element != null)
            {
                IWebElement boy = driver.FindElement(By.XPath("/html/body/div[5]/div[3]/div[1]/div[2]/div[2]/div[2]/div[1]/div/div[4]/div[1]/div[2]/div/div[2]/div[2]"));
                IList<IWebElement> list_boy = boy.FindElements(By.TagName("a"));
                IList<IWebElement> boy_secilemez = boy.FindElements(By.ClassName("disabled"));

                IList<IWebElement> boy_secilebilir = list_boy.Except(boy_secilemez).ToList();

                Console.Write("toplam boy: " + boy_secilebilir.Count().ToString());
                boy_secilebilir.ElementAt(new Random().Next(0, boy_secilebilir.Count - 1)).Click();

                Thread.Sleep(2000);
            }

            IWebElement sepete_ekle = driver.FindElement(By.LinkText("SEPETE EKLE"));
            sepete_ekle.Click();

            Thread.Sleep(1000);

            IWebElement sepete_git = driver.FindElement(By.ClassName("header-cart"));
            sepete_git.Click();

            Thread.Sleep(1000);

            IWebElement sepeti_artir = driver.FindElement(By.LinkText("+"));
            sepeti_artir.Click();

            Thread.Sleep(1000);

            IWebElement sepeti_sil = driver.FindElement(By.ClassName("cart-square-link"));
            sepeti_sil.Click();

            Thread.Sleep(1000);

            IWebElement sepeti_sil_onay = driver.FindElement(By.LinkText("Sil"));
            sepeti_sil_onay.Click();



            Thread.Sleep(3000);
        }

        [TearDown]
        public void EndTest()
        {
            //close the browser  
            driver.Close();
            Console.Write("test sonlandı");
        }

    }
}
