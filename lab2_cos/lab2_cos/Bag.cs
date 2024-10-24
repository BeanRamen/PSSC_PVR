namespace lab2_cos
{
    public static partial class Bag
    {
        public interface IBag{ }

        public record UnvalidatedBag(IReadOnlyCollection<UnValidCart> ShoppieList) : IBag;
        public record InvalidatedBag(IReadOnlyCollection<UnValidCart> ShoppieList,string Reason):IBag;
        public record ValidBag(IReadOnlyCollection<UnValidCart> ShoppieList):IBag;
        public record PublishBag(IReadOnlyCollection<UnValidCart> ShoppieList, DateTime PublishDate) : IBag;
    }
}