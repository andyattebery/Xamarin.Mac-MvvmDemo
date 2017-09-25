using AppKit;
using Autofac;
using Autofac.Extras.CommonServiceLocator;
using Foundation;
using Microsoft.Practices.ServiceLocation;
using MvvmPOC.ViewModels;
using ReactiveUI;
using Splat;

namespace MvvmPOC
{
    [Register("AppDelegate")]
    public class AppDelegate : NSApplicationDelegate
    {
        public AppDelegate()
        {
            ConfigureReactiveUiSplat();
            ConfigureCommonServiceLocator();
        }


        public override void DidFinishLaunching(NSNotification notification)
        {
        }

        public override void WillTerminate(NSNotification notification)
        {
            // Insert code here to tear down your application
        }

        private void ConfigureReactiveUiSplat()
        {
            Locator.CurrentMutable.InitializeSplat();
            Locator.CurrentMutable.InitializeReactiveUI();

            Locator.CurrentMutable.RegisterLazySingleton(() => new CanActivateViewFetcher(), typeof(IActivationForViewFetcher));
        }

        private void ConfigureCommonServiceLocator()
        {
            var container = CreateContainer();

            var csl = new AutofacServiceLocator(container);
            ServiceLocator.SetLocatorProvider(() => csl);
        }


        private static IContainer CreateContainer()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<DemoViewModel>();

            return builder.Build();
        }



    }


}
