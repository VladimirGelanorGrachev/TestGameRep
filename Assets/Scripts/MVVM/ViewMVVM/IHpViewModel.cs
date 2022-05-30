using System;
using MVVM.Model;
namespace MVVM.ViewModel
{
    public interface IHpViewModel
    {
        IHpModel HpModel { get; }
        bool IsDead { get; }
        void ApplyDamage(float damage);
        event Action<float> OnHpChange;
    }
}
