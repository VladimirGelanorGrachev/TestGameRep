namespace MVVM.Model
{
    internal sealed class HpModel : IHpModel
    {
        public float MaxHp { get; }
        public float CurrentHp { get; set; }
        public HpModel(float maxHp)
        {
            MaxHp = maxHp;
            CurrentHp = MaxHp;
        }
    }
}
