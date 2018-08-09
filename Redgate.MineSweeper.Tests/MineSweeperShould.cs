using System;
using Shouldly;
using Xunit;

namespace Redgate.MineSweeper.Tests
{
    public class MineSweeperShould
    {
        [Theory]
        [InlineData("*")]
        [InlineData("****")]
        [InlineData("**\n**")]
        public void Generate_hintfield_for_field_with_mines_only(string field)
        {
            var hintField = GenerateHintField(field);
            hintField.ShouldBe(field);
        }

        [Theory]
        [InlineData(".", "0")]
        [InlineData("....", "0000")]
        [InlineData("..\n..", "00\n00")]
        public void Generate_hintfield_for_field_with_no_mines(string field, string expectedHintField)
        {
            var hintField = GenerateHintField(field);
            hintField.ShouldBe(expectedHintField);
        }

        [Theory]
        [InlineData("*.\n..", "*1\n11")]
        [InlineData(".*\n..", "1*\n11")]
        [InlineData("..\n*.", "11\n*1")]
        [InlineData("..\n.*", "11\n1*")]
        public void Generate_hintfield_for_2x2_field_with_single_mine(string field, string expectedHintField)
        {
            var hintField = GenerateHintField(field);
            hintField.ShouldBe(expectedHintField);
        }

        [Theory]
        [InlineData("**\n..", "**\n22")]
        [InlineData("..\n**", "22\n**")]
        [InlineData(".*\n.*", "2*\n2*")]
        public void Generate_hintfield_for_2x2_field_with_two_mines(string field, string expectedHintField)
        {
            var hintField = GenerateHintField(field);
            hintField.ShouldBe(expectedHintField);
        }

        [Fact(Skip = "Not yet implemented")]
        public void Generate_hintfield_for_3x3_field_with_many_mines()
        {
            var field = string.Join('\n', new[] {
                "*..",
                ".*.",
                "..."
            });

            var expectedHintField = string.Join('\n', new[] {
                "*21",
                "2*1",
                "111"
            });

            var hintField = GenerateHintField(field);
            hintField.ShouldBe(expectedHintField);
        }

        private string GenerateHintField(string field)
        {
            var mineSweeper = new MineSweeper();
            return mineSweeper.GenerateHintField(field);
        }
    }
}
