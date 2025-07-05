using Godot;
using System;
using System.Collections.Generic;

public partial class Arena : Node2D
{
    [Export] private Color _gridColor = new Color(0.5f, 0.5f, 0.5f, 0.3f); // Faint gray
    [Export] private float _lineWidth = 1f; // Thin lines for clarity
    private List<Line2D> _lines = new();
    public override void _Ready()
    {
        var arenaSize = new Vector2(4096, 4096);
        var cellSize = 128;
        // Draw vertical lines
        for (float x = 0; x <= arenaSize.X; x += cellSize)
        {
            var line = new Line2D();
            line.Width = _lineWidth;
            line.DefaultColor = _gridColor;
            line.Points = new Vector2[] { new Vector2(x, 0), new Vector2(x, arenaSize.Y) };
            AddChild(line);
        }

        // Draw horizontal lines
        for (float y = 0; y <= arenaSize.Y; y += cellSize)
        {
            var line = new Line2D();
            line.Width = _lineWidth;
            line.DefaultColor = _gridColor;
            line.Points = new Vector2[] { new Vector2(0, y), new Vector2(arenaSize.X, y) };
            AddChild(line);
            _lines.Add(line);
        }
    }
    public override void _Process(double dt) {

        GD.Print("Area Position: ", GlobalPosition, _lines[0].GlobalPosition);
    }
}
