using Godot;
using System;

public enum SpellCode
{
    kAoeBomb,
    kAoeCleave,
    kAoeCone,
    kAoeBeam,
    kProjectile,
    kProjectileFan,
    kTargeted,
    kSummonRanged,
    kSummonBigMelee,
    kSummonSmallMelees,
    kDash,
    kDashTargeted,
    kProjectileDash,
}
public enum SpellTraitCode
{
    kMagicRatio,
    kPhysicalRatio,
    kSize,
    kRange,
    kSpeed,
    kCastTime,
    kHealth,
    kSlow,
    kSnare,
    kPhysicalDot,
    kMagicDot,
    kSheild,
    kDuration,
    kCharges,
    kCasts,
    kPeirce,
    kChain,
    kUntargetable,
}
public record struct SpellTrait(SpellTraitCode Code, Int32 Amt);

public class Spell
{
    public SpellCode Code;
    public SpellTrait[] Traits = new SpellTrait[4];
    public Double Cooldown = 5;
}

public enum QuirkCode
{
    kNone,
    // mark target location 1s recast async from marks to player
    kBoomerang,
    // async cast time
    kAfterImage,
    // hold for cast time increase traits up to 3*
    kRitual,
    // 0.2* hold to recast every 0.5 seconds with capped turn speed
    kBarrage,
    // marks target location, touching mark rgsets
    kRelentless,
    // taking damage gains stacks consumed up to 5* 
    kRevenge,
    // async recast spell after 1s
    kMimic,
    // grant enemy stacks consume on death spawning small melee 
    kTrojanHorse,
    // kill an ally to gain proportional stats
    kMachiavellian,
    // grants allies this spells damage type
    kTetheredMinds,
    // furthest part of hitbox gains x3 damage
    kSweetSpot,
    // hitting the same ability within 2s does 2*
    kOverload,
    // consume status to deal proportial damage
    kEvicerate,
    // 3* traits but async reverse cast spell 1s after
    kOppurtunity,
    // 2* but enemy casts spell at you
    kBulletHell,
}
public record struct Quirk(QuirkCode Code, Int32 Spell);

public enum Talent
{
    kNone,
    kMiseryLovesCompany, // overlapping persists share effects and duration once
    kBattleHigh, // attacks gain stacks at 100 gain 2x stats
    kViralPathogen, // dots spread to nearby enemies
    kDominoEffect, // status effects stack for 1.25x
    kSniper, // deal more damage based on distance from origin
    kAcrobatsEdge, // near miss grants stacks of damage
}

public enum Item
{
    kNone,
}

