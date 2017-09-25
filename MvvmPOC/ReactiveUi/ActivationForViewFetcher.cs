using System;
using System.Reactive.Linq;
using System.Reflection;
using ReactiveUI;

namespace MvvmPOC.ReactiveUi
{
    // TODO: This needs to be propertly implemented for Xamarin.Mac.
    // The implementation could be stolen from Xamarin.iOS
    // Otherwise there could be memory leaks
    public class ActivationForViewFetcher : IActivationForViewFetcher
    {
        public int GetAffinityForView(Type view)
        {
            return (typeof(ICanActivate).GetTypeInfo().IsAssignableFrom(view.GetTypeInfo())) ?
                10 : 0;
        }

        public IObservable<bool> GetActivationForView(IActivatable view)
        {
            var ca = view as ICanActivate;
            return ca.Activated.Select(_ => true).Merge(ca.Deactivated.Select(_ => false));
        }
    }
}
