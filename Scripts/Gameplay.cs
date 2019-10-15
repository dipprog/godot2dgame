using Godot;
using System;

public class Gameplay : Node
{
    [Export]
    private PackedScene greenZombie, redZombie, ghost;
    private Vector2 spawn_left = new Vector2(-5000, 505f);
    private Vector2 spawn_right = new Vector2(6200f, 505f);
    private Timer restart;
    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        restart = GetNode<Timer>("Restart");
    }

    void _on_Monster_Spawn()
    {
        int randEnemy = new Random().Next(0, 3);
        Monster newMonster = null;
        switch (randEnemy)
        {
            case 0:
                newMonster = greenZombie.Instance() as Monster;
                break;
            case 1:
                newMonster = redZombie.Instance() as Monster;
                break;
            case 2:
                newMonster = ghost.Instance() as Monster;
                break;
        }
        Vector2 temp;
        // spawn to the right
        if (new Random().Next(0, 2) > 0)
        {
            temp = spawn_right;
            newMonster.moveLeft = true;
        }
        else
        {
            // spawn left
            temp = spawn_left;
        }
        newMonster.SetPosition(temp);
        AddChild(newMonster);
    }
    public void PlayerDied()
    {
        restart.Start();
    }
    void _on_Player_Died()
    {
        GetTree().ReloadCurrentScene();
    }

} // class

