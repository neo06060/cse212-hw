/// <summary>
/// Defines a maze using a dictionary. The dictionary is provided by the
/// user when the Maze object is created. The dictionary will contain the
/// following mapping:
///
/// (x,y) : [left, right, up, down]
///
/// 'x' and 'y' are integers and represents locations in the maze.
/// 'left', 'right', 'up', and 'down' are boolean are represent valid directions
///
/// If a direction is false, then we can assume there is a wall in that direction.
/// If a direction is true, then we can proceed.  
///
/// If there is a wall, then throw an InvalidOperationException with the message "Can't go that way!".  If there is no wall,
/// then the 'currX' and 'currY' values should be changed.
/// </summary>
using System;
using System.Collections.Generic;

public class Maze
{
    private readonly Dictionary<ValueTuple<int, int>, bool[]> _mazeMap;
    private int _currX = 1;
    private int _currY = 1;

    /// <summary>
    /// Initializes a new instance of the Maze class with a maze map.
    /// The maze map defines valid movement directions for each position.
    /// </summary>
    /// <param name="mazeMap">A dictionary mapping positions (x, y) to valid movement directions.</param>
    public Maze(Dictionary<ValueTuple<int, int>, bool[]> mazeMap)
    {
        _mazeMap = mazeMap;
    }

    /// <summary>
    /// Moves left if possible. Throws an exception if the move is invalid.
    /// </summary>
    public void MoveLeft()
    {
        if (!_mazeMap.TryGetValue((_currX, _currY), out var directions) || !directions[0])
        {
            throw new InvalidOperationException("Can't go that way!");
        }

        _currX--; // Move left
    }

    /// <summary>
    /// Moves right if possible. Throws an exception if the move is invalid.
    /// </summary>
    public void MoveRight()
    {
        if (!_mazeMap.TryGetValue((_currX, _currY), out var directions) || !directions[1])
        {
            throw new InvalidOperationException("Can't go that way!");
        }

        _currX++; // Move right
    }

    /// <summary>
    /// Moves up if possible. Throws an exception if the move is invalid.
    /// </summary>
    public void MoveUp()
    {
        if (!_mazeMap.TryGetValue((_currX, _currY), out var directions) || !directions[2])
        {
            throw new InvalidOperationException("Can't go that way!");
        }

        _currY--; // Move up
    }

    /// <summary>
    /// Moves down if possible. Throws an exception if the move is invalid.
    /// </summary>
    public void MoveDown()
    {
        if (!_mazeMap.TryGetValue((_currX, _currY), out var directions) || !directions[3])
        {
            throw new InvalidOperationException("Can't go that way!");
        }

        _currY++; // Move down
    }

    /// <summary>
    /// Returns the current status of the player in the maze.
    /// </summary>
    /// <returns>A string representing the current location (x, y).</returns>
    public string GetStatus()
    {
        return $"Current location (x={_currX}, y={_currY})";
    }
}
