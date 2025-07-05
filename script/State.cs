using Godot;
using System;
using System.Collections.Generic;
using System.Linq;

public enum HeroCode
{
    kSurge,
    kWard,
    kViper,
    kTitan,
}

public enum DamageType
{
    kPhysical,
    kMagic,
}

public class HeroState
{
    public Spell[] Spells;
    public Item[] Items = new Item[8];
    public Talent[] Talents = new Talent[4];
    public Quirk[] Quirks = new Quirk[8];
    public Single MaxHealth;
    public Single AttackRange;
    public DamageType AttackType;
    public HeroState(HeroCode code)
    {
        Spells = Enumerable.Range(0, 4).Select(_ => new Spell()).ToArray();
        switch (code)
        {
            case HeroCode.kSurge:
                MaxHealth = 1000;
                AttackType = DamageType.kMagic;
                AttackRange = 10;
                Spells[0].Code = SpellCode.kAoeBeam;
                Spells[0].Traits[0] =
                    new SpellTrait(SpellTraitCode.kMagicRatio, 7);
                Spells[0].Traits[1] =
                  new SpellTrait(SpellTraitCode.kRange, 4);
                Spells[0].Traits[2] =
                  new SpellTrait(SpellTraitCode.kSize, 1);
                Spells[0].Traits[3] =
                  new SpellTrait(SpellTraitCode.kCastTime, 2);
                Spells[1].Code = SpellCode.kAoeBomb;
                Spells[1].Traits[0] =
                    new SpellTrait(SpellTraitCode.kMagicRatio, 2);
                Spells[1].Traits[1] =
                  new SpellTrait(SpellTraitCode.kRange, -2);
                Spells[1].Traits[2] =
                  new SpellTrait(SpellTraitCode.kSlow, 7);
                Spells[1].Traits[3] =
                  new SpellTrait(SpellTraitCode.kSpeed, 0);
                Spells[2].Code = SpellCode.kProjectile;
                Spells[2].Traits[0] =
                    new SpellTrait(SpellTraitCode.kMagicRatio, 4);
                Spells[2].Traits[1] =
                  new SpellTrait(SpellTraitCode.kRange, -2);
                Spells[2].Traits[2] =
                  new SpellTrait(SpellTraitCode.kSnare, 6);
                Spells[2].Traits[3] =
                  new SpellTrait(SpellTraitCode.kSpeed, 0);
                Spells[3].Code = SpellCode.kAoeBomb;
                Spells[3].Traits[0] =
                  new SpellTrait(SpellTraitCode.kMagicRatio, 7);
                Spells[3].Traits[1] =
                  new SpellTrait(SpellTraitCode.kRange, 16);
                Spells[3].Traits[2] =
                  new SpellTrait(SpellTraitCode.kSize, -4);
                Spells[3].Traits[3] =
                  new SpellTrait(SpellTraitCode.kCasts, 5);
                break;
            case HeroCode.kWard:
                MaxHealth = 1000;
                AttackType = DamageType.kMagic;
                AttackRange = 12;
                Spells[2].Code = SpellCode.kAoeBomb;
                Spells[0].Traits[0] =
                    new SpellTrait(SpellTraitCode.kMagicRatio, 3);
                Spells[0].Traits[1] =
                  new SpellTrait(SpellTraitCode.kSnare, 9);
                Spells[0].Traits[2] =
                  new SpellTrait(SpellTraitCode.kSize, 3);
                Spells[0].Traits[3] =
                  new SpellTrait(SpellTraitCode.kSpeed, -3);
                Spells[1].Code = SpellCode.kAoeBeam;
                Spells[1].Traits[0] =
                    new SpellTrait(SpellTraitCode.kMagicRatio, 4);
                Spells[1].Traits[1] =
                  new SpellTrait(SpellTraitCode.kSize, 4);
                Spells[1].Traits[2] =
                  new SpellTrait(SpellTraitCode.kSlow, 6);
                Spells[1].Traits[3] =
                  new SpellTrait(SpellTraitCode.kCastTime, 8);
                Spells[2].Code = SpellCode.kProjectile;
                Spells[2].Traits[0] =
                    new SpellTrait(SpellTraitCode.kMagicRatio, 14);
                Spells[2].Traits[1] =
                  new SpellTrait(SpellTraitCode.kRange, 4);
                Spells[2].Traits[2] =
                  new SpellTrait(SpellTraitCode.kPeirce, 2);
                Spells[2].Traits[3] =
                  new SpellTrait(SpellTraitCode.kSpeed, -14);
                Spells[3].Code = SpellCode.kAoeBomb;
                Spells[3].Traits[1] =
                  new SpellTrait(SpellTraitCode.kMagicRatio, 8);
                Spells[3].Traits[0] =
                  new SpellTrait(SpellTraitCode.kDuration, 12);
                Spells[3].Traits[2] =
                  new SpellTrait(SpellTraitCode.kSize, 4);
                Spells[3].Traits[3] =
                  new SpellTrait(SpellTraitCode.kSlow, 8);
                break;
            case HeroCode.kViper:
                MaxHealth = 1500;
                AttackType = DamageType.kPhysical;
                AttackRange = 2;
                Spells[2].Code = SpellCode.kProjectileDash;
                Spells[0].Traits[0] =
                    new SpellTrait(SpellTraitCode.kPhysicalRatio, 2);
                Spells[0].Traits[1] =
                  new SpellTrait(SpellTraitCode.kPeirce, 2);
                Spells[0].Traits[2] =
                  new SpellTrait(SpellTraitCode.kSize, -4);
                Spells[0].Traits[3] =
                  new SpellTrait(SpellTraitCode.kRange, 5);
                Spells[1].Code = SpellCode.kAoeCleave;
                Spells[1].Traits[0] =
                    new SpellTrait(SpellTraitCode.kSheild, 4);
                Spells[1].Traits[1] =
                  new SpellTrait(SpellTraitCode.kSize, -2);
                Spells[1].Traits[2] =
                  new SpellTrait(SpellTraitCode.kUntargetable, 2);
                Spells[1].Traits[3] =
                  new SpellTrait(SpellTraitCode.kCastTime, 5);
                Spells[2].Code = SpellCode.kProjectileFan;
                Spells[2].Traits[0] =
                    new SpellTrait(SpellTraitCode.kPhysicalRatio, 9);
                Spells[2].Traits[1] =
                  new SpellTrait(SpellTraitCode.kRange, -4);
                Spells[2].Traits[2] =
                  new SpellTrait(SpellTraitCode.kPeirce, 2);
                Spells[2].Traits[3] =
                  new SpellTrait(SpellTraitCode.kSize, 4);
                Spells[3].Code = SpellCode.kDash;
                Spells[3].Traits[1] =
                  new SpellTrait(SpellTraitCode.kCastTime, -8);
                Spells[3].Traits[0] =
                  new SpellTrait(SpellTraitCode.kSlow, 2);
                Spells[3].Traits[2] =
                  new SpellTrait(SpellTraitCode.kSpeed, 6);
                Spells[3].Traits[3] =
                  new SpellTrait(SpellTraitCode.kRange, 2);
                break;
            case HeroCode.kTitan:
                MaxHealth = 2000;
                AttackType = DamageType.kPhysical;
                AttackRange = 2;
                Spells[2].Code = SpellCode.kAoeBeam;
                Spells[0].Traits[0] =
                    new SpellTrait(SpellTraitCode.kPhysicalRatio, 3);
                Spells[0].Traits[1] =
                  new SpellTrait(SpellTraitCode.kRange, 8);
                Spells[0].Traits[2] =
                  new SpellTrait(SpellTraitCode.kSize, 4);
                Spells[0].Traits[3] =
                  new SpellTrait(SpellTraitCode.kCastTime, -5);
                Spells[1].Code = SpellCode.kAoeCleave;
                Spells[1].Traits[0] =
                    new SpellTrait(SpellTraitCode.kSheild, 4);
                Spells[1].Traits[1] =
                  new SpellTrait(SpellTraitCode.kSize, 4);
                Spells[1].Traits[2] =
                  new SpellTrait(SpellTraitCode.kSlow, 2);
                Spells[1].Traits[3] =
                  new SpellTrait(SpellTraitCode.kCastTime, -5);
                Spells[2].Code = SpellCode.kDashTargeted;
                Spells[2].Traits[0] =
                    new SpellTrait(SpellTraitCode.kPhysicalRatio, 3);
                Spells[2].Traits[1] =
                  new SpellTrait(SpellTraitCode.kRange, 4);
                Spells[2].Traits[2] =
                  new SpellTrait(SpellTraitCode.kPeirce, 2);
                Spells[2].Traits[3] =
                  new SpellTrait(SpellTraitCode.kChain, 4);
                Spells[3].Code = SpellCode.kTargeted;
                Spells[3].Traits[1] =
                  new SpellTrait(SpellTraitCode.kPhysicalDot, 8);
                Spells[3].Traits[0] =
                  new SpellTrait(SpellTraitCode.kSlow, 12);
                Spells[3].Traits[2] =
                  new SpellTrait(SpellTraitCode.kDuration, 4);
                Spells[3].Traits[3] =
                  new SpellTrait(SpellTraitCode.kSize, 8);
                break;
        }
    }
}
public class State
{
    public static HeroState Player;
    public static void Reset(HeroCode code)
    {
        Player = new HeroState(code);
    }
}
