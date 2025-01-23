using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualBasic.FileIO;

public class Basketball {
    public static void Run() {
        var players = new Dictionary<string, int>();

        using var reader = new TextFieldParser("basketball.csv");
        reader.TextFieldType = FieldType.Delimited;
        reader.SetDelimiters(",");
        reader.ReadFields(); // Ignore header row

        while (!reader.EndOfData) {
            var fields = reader.ReadFields()!;
            var playerId = fields[0];
            var points = int.Parse(fields[8]);

            if (!players.ContainsKey(playerId)) {
                players[playerId] = 0;
            }
            players[playerId] += points;
        }

        // Sort by total points in descending order and get the top 10
        var topPlayers = players
            .OrderByDescending(p => p.Value)
            .Take(10)
            .ToArray();

        // Display the top 10 players
        Console.WriteLine("Top 10 Players by Total Points:");
        foreach (var (playerId, totalPoints) in topPlayers) {
            Console.WriteLine($"{playerId}: {totalPoints}");
        }
    }
}
