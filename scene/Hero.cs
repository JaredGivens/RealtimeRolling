using Godot;
using System;
using System.Linq;

public class HeroStats
{
}

public partial class Hero : Node2D
{
    public HeroState State;
    public Single Health;
    public Single MaxHealth;
    public Single Mana;
    public Single MaxMana;
    public Single Magic;
    public Single Physical;
    public Single Speed = 256;
    public Single AttackRange;
    public Single AttackSpeed;
    public DamageType AttackType;
    public Single AttackRatio;
    public Timer[] SpellTimers;
    [Export]
    public Polygon2D Sprite;
    [Export]
    public TextureProgressBar HealthBar;
    [Export]
    public TextureProgressBar ManaBar;
    public override void _Ready() {
        Enumerable.Range(0, 4).Select(_ => {
                var timer = new Timer();
                timer.OneShot = true;
                AddChild(timer);
                return timer;
            }).ToArray();
    }
}
