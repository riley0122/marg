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
    class ArgHandler(string[] args)
    {
        private string[] args = args;
        private string InputFilePath = "";
        private string OutputFilePath = "";
        private List<ActionType> Actions = [];

        public bool Handle()
        {
            if (this.args.Length < 1)
            {
                return false;
            }

            string actionString = this.args[0];
            switch (actionString)
            {
                case "compile":
                    this.Actions = [ActionType.Compile];
                    break;

                case "assemble":
                    this.Actions = [ActionType.Assemble];
                    break;

                case "make":
                    this.Actions = [ActionType.Compile, ActionType.Assemble];
                    break;

                case "run":
                    this.Actions = [ActionType.Compile, ActionType.Assemble, ActionType.Run];
                    break;

                default:
                    Console.WriteLine("Invalid action! These are your options:");
                    Console.WriteLine("\t - compile");
                    Console.WriteLine("\t - assemble");
                    Console.WriteLine("\t - make");
                    Console.WriteLine("\t - run");
                    return false;
            }

            if (this.args.Length < 2)
            {
                Console.WriteLine("No input file provided!");
                return false;
            }

            this.InputFilePath = this.args[1];

            for (int i = 2; i < this.args.Length; i += 2)
            {
                if (this.args.Length < i + 2)
                {
                    Console.WriteLine("Option " + this.args[i] + " does not have a value.");
                    return false;
                }

                string option = this.args[i];
                string value = this.args[i + 1];

                switch (option)
                {
                    case "-o":
                    case "--output":
                        this.OutputFilePath = value;
                        break;

                    default:
                        Console.WriteLine("Invalid option " + this.args[i]);
                        return false;
                }
            }

            return true;
        }

        public ActionType GetNextAction()
        {
            ActionType first = this.Actions[0];
            this.Actions.Remove(first);
            return first;
        }

        public string GetInputFilePath()
        {
            return this.InputFilePath;
        }

        public string GetOutputFilePath()
        {
            return this.OutputFilePath;
        }
    }
}
