using BeverageVend.Data;
using BeverageVend.Enums;
using Blazored.Toast.Services;
using Microsoft.AspNetCore.Components;

namespace BeverageVend.ComponentsBase
{
    public class BeverageBase : ComponentBase
    {
        [Inject] IToastService? toastServices { get; set; }
        [Inject] ILogger<BeverageBase>? logger { get; set; }
        [Inject] 
        public Vend? vend { get; set; }

        public int selected { get; set; }

        public bool isDisabled = false;

        public async void CreateBeverage()
        {
            try
            {
                isDisabled = true;
                toastServices.ShowInfo("Boiling water","Starting");
                await Task.Delay(TimeSpan.FromSeconds(4));

                switch (selected)
                {
                    case 0:
                        toastServices.ShowInfo("Prepairing your Coffee","Creating");
                        await Task.Delay(TimeSpan.FromSeconds(4));
                        vend.Beverage = Beverage.Coffee;
                        break;
                    case 1:
                        toastServices.ShowInfo("Prepairing your Tea", "Creating");
                        await Task.Delay(TimeSpan.FromSeconds(4));
                        vend.Beverage = Beverage.Tea;
                        break;
                    case 2:
                        toastServices.ShowInfo("Prepairing your Chocolate", "Creating");
                        await Task.Delay(TimeSpan.FromSeconds(4));
                        vend.Beverage = Beverage.Chocolate;
                        break;
                }
                toastServices.ShowInfo("Your bevarage is being dispenced", "Dispencing");
                await Task.Delay(TimeSpan.FromSeconds(4));

                toastServices.ShowSuccess("Thank you for your order.");

                Reset();

                await InvokeAsync(() =>  StateHasChanged());              
            }
            catch (Exception ex)
            {
                Reset();

                toastServices.ShowError("Our Appolagize your order has not been dispenced", "Sorry");

                await InvokeAsync(() => StateHasChanged());
            }                 
        }

        public void Reset()
        {
            isDisabled = false;
            vend.Milk = false;
            vend.Sugar = false;
            vend.Lemon = false;
            selected = 0;
        }

        public void Coffee()
        {
            selected = 0;
            CreateBeverage();
        }

        public void Tea()
        {
            selected = 1;
            CreateBeverage();
        }
        public void Chocolate()
        {
            selected = 2;
            CreateBeverage();
        }

    }
}
