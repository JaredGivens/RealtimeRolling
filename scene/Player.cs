using Godot;
using System;

public partial class Player : CharacterBody2D
{
    [Export]
    private Hero _hero;
    [Export]
    private Camera2D _camera;
    public override void _Ready()
    {
        MotionMode = MotionModeEnum.Floating;
    }
    public override void _PhysicsProcess(double delta)
    {
        // Get mouse position and aim direction
        Vector2 mousePos = GetGlobalMousePosition();
        Vector2 aimDirection = (mousePos - GlobalPosition).Normalized();

        // Rotate sprite to face mouse
        _hero.Sprite.Rotation = aimDirection.Angle() - MathF.PI / 2;

        var velocity = new Vector2();
        if (Input.IsActionPressed("move_up")) velocity += aimDirection; // Move toward mouse
        if (Input.IsActionPressed("move_down")) velocity -= aimDirection; // Move away from mouse
        if (Input.IsActionPressed("move_left")) velocity += new Vector2(-aimDirection.Y, aimDirection.X); // Strafe left
        if (Input.IsActionPressed("move_right")) velocity += new Vector2(aimDirection.Y, -aimDirection.X); // Strafe right


        // Normalize velocity to prevent faster diagonal movement
        Velocity = velocity.Normalized() * _hero.Speed;
        if (Velocity.Length() != 0) {
            MoveAndSlide();
        }
        GD.Print("hero pos:", _hero.GlobalPosition);

        // Cast spell
        for (Int32 i = 0; i < 1; ++i)
        {
            if (Input.IsActionJustPressed($"spell{i}"))
            {
                if (!_hero.SpellTimers[i].IsStopped())
                {
                    _hero.SpellTimers[i].Start(_hero.State.Spells[i].Cooldown);
                }
            }
        }
    }
}
