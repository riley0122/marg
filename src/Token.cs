// Marg programming language
// Copyright (C) 2026 Riley0122
//
// This program is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
//
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
// 
// You should have received a copy of the GNU General Public License
// along with this program.  If not, see <https://www.gnu.org/licenses/>.

namespace marg
{
    class Token
    {
        private string TextContent;
        private int Index = 0;
        private TokenType type = TokenType.None;

        public Token(string TextContent)
        {
            this.TextContent = TextContent;
        }

        private bool HasNextToken()
        {
            return this.Index < this.TextContent.Length;
        }

        private char GetNextToken()
        {
            this.Index += 1;
            return this.TextContent[this.Index - 1];
        }

        public void Evaluate()
        {
            if (this.TextContent.Trim() == "") return;

            while (this.HasNextToken())
            {
                char c = this.GetNextToken();
                
                Console.Write(c);
            }

            Console.Write("\n");
        }

        public TokenType GetTokenType()
        {
            return this.type;
        }
    }
}