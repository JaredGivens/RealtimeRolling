using Godot;
using System.Collections.Generic;

public partial class Arena : Node2D
{
    [Export] private Color _gridColor = new Color(0.5f, 0.5f, 0.5f, 0.3f); // Faint gray for grid
    [Export] private Color _boundaryColor = new Color(0.8f, 0.8f, 0.8f, 0.8f); // Brighter gray for boundaries
    [Export] private float _gridLineWidth = 1f; // Thin lines for grid
    [Export] private float _boundaryLineWidth = 3f; // Thicker lines for boundaries
    [Export] private Player _player; 
    [Export] private Vector2 _arenaSize = new Vector2(4096, 4096);

    public override void _Ready()
    {
        var cellSize = 128;

        // Draw vertical grid lines
        for (float x = 0; x <= _arenaSize.X; x += cellSize)
        {
            var line = new Line2D();
            line.Width = _gridLineWidth;
            line.DefaultColor = _gridColor;
            line.Points = new Vector2[] { new Vector2(x, 0), new Vector2(x, _arenaSize.Y) };
            AddChild(line);
        }

        // Draw horizontal grid lines
        for (float y = 0; y <= _arenaSize.Y; y += cellSize)
        {
            var line = new Line2D();
            line.Width = _gridLineWidth;
            line.DefaultColor = _gridColor;
            line.Points = new Vector2[] { new Vector2(0, y), new Vector2(_arenaSize.X, y) };
            AddChild(line);
        }

        // Add boundary lines and colliders
        AddBoundary(0, 0, _arenaSize.X, _boundaryLineWidth, Vector2.Down, new Vector2(_arenaSize.X, 0)); // Top
        AddBoundary(0, _arenaSize.Y, _arenaSize.X, _boundaryLineWidth, Vector2.Up, new Vector2(_arenaSize.X, _arenaSize.Y)); // Bottom
        AddBoundary(0, 0, _arenaSize.Y, _boundaryLineWidth, Vector2.Right, new Vector2(0, _arenaSize.Y)); // Left
        AddBoundary(_arenaSize.X, 0, _arenaSize.Y, _boundaryLineWidth, Vector2.Left, new Vector2(_arenaSize.X, _arenaSize.Y)); // Right
        _player.GlobalPosition = new Vector2(256, _arenaSize.Y - 256);
    }

    private void AddBoundary(float x, float y, float length, float width, Vector2 normal, Vector2 endPoint)
    {
        // Add visual boundary line
        var line = new Line2D();
        line.Width = _boundaryLineWidth;
        line.DefaultColor = _boundaryColor;
        line.Points = new Vector2[] { new Vector2(x, y), endPoint };
        AddChild(line);

        // Add collider
        var staticBody = new StaticBody2D();
        var collisionShape = new CollisionShape2D();
        var shape = new RectangleShape2D();

        // Set collider size and position
        if (normal == Vector2.Down || normal == Vector2.Up) // Horizontal boundaries
        {
            shape.Size = new Vector2(length, width);
            collisionShape.Position = new Vector2(x + length / 2, y);
        }
        else // Vertical boundaries
        {
            shape.Size = new Vector2(width, length);
            collisionShape.Position = new Vector2(x, y + length / 2);
        }

        collisionShape.Shape = shape;
        staticBody.AddChild(collisionShape);
        AddChild(staticBody);
    }

    public override void _Process(double dt)
    {
    }
}
