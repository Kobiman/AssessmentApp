using AssessmentApp.Shared.Models.Dtos;

namespace AssessmentApp.Client.Events
{
    //public interface IAssementService
    //{
    //    IList<CartItem> Products { get; }
    //    void AddToCart(CartItem cartItem);
    //    void RemoveFromCart(CartItem cartItem);
    //    void ClearItems();
    //}
    public interface IAssementFormObserver
    {
        void Update(IList<ResponseDto> data);
    }
    public interface IAssementFormNotifier
    {
        void Subscribe(IAssementFormObserver observer);
        void Unsubscribe(IAssementFormObserver observer);
        void Notify(IList<ResponseDto> data);
    }

    public class AssementFormNotifier : IAssementFormNotifier
    {
        private static IList<IAssementFormObserver> observers;
        public AssementFormNotifier()
        {
            observers = new List<IAssementFormObserver>();

        }

        public void Subscribe(IAssementFormObserver observer)
        {
            observers.Add(observer);
        }

        public void Unsubscribe(IAssementFormObserver observer)
        {
            observers.Remove(observer);
        }

        public void Notify(IList<ResponseDto> data)
        {
            foreach (IAssementFormObserver observer in observers)
            {
                Task.Run(() => observer.Update(data));
            }
        }
    }
}
