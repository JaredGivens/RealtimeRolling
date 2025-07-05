using Godot;
using System;


public partial class MainMenu : Control
{
  [Export]
  private Button _startButton;
  [Export]
  private OptionButton _playerHeroOption;
  [Export]
  private PackedScene _arenaScene;
  public override void _Ready() {
    _startButton.Pressed += () => {
      State.Reset((HeroCode)_playerHeroOption.Selected);
      GetTree().ChangeSceneToPacked(_arenaScene);
    };
  }
}
