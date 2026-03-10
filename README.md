# marg

**marg** is a superset of [butters](https://github.com/riley0122/butters/) that extends the language with advanced features while maintaining full backward compatibility with existing butters code.

## What is marg?

marg (margarine) builds upon the [butters programming language](https://github.com/riley0122/butters/), a section-based language written in C# with a highly customizable compiler and runtime. If you've written butters code, it runs unchanged in marg. But marg adds powerful new capabilities for writing more complex programs.

## About Butters

Butters is a structured programming language that organizes code into sections:
- **META** — File metadata (author, project, version, license)
- **DEFINE** — Variable declarations
- **DYNAMIC** — Module imports
- **STATIC** — Library imports
- **CODE** — Executable code

Butters programs compile to an intermediate JSON-like structure that can be further processed or executed.

## What marg Adds

marg extends butters with:
- **Classes** — Object-oriented programming with class definitions, methods, and properties
- **Enhanced Imports** — Full-featured module system with proper namespacing and dependencies
- **Advanced OOP** — Build complex, maintainable programs with inheritance and encapsulation

marg adds some sections for this:
- **CLASS** - Class function definitions
- **IMPORT** - Combined dynamic and static imports

All butters code remains fully compatible and runs without modification in marg.

Marg also removes explicit variable types and determines type by value, making programs more concise.

## Quick Start

### Installation

```bash
git clone https://github.com/riley0122/marg.git
cd marg
```

### Basic Butters Program (works in marg!)

```butters
#section META
*author You
*project HelloWorld

#section DEFINE
string message Hello, Butters!

#section CODE
out message
```

### Classes in marg

**Greeter.marg** — Define a class:
```butters
#section META
*author You
*project greeter

-- Private class member variable
#section DEFINE
(private) var name

-- Class definition
#section CLASS
*name Greeter

-- Constructor: takes a name parameter and assigns to my.name
void Greeter takes name
$
   cvar my.name / name
%

-- Instance method: prints the name
void greet
$
  out my.name
%
```

**Main.marg** — Use the class:
```butters
#section META
*author You
*project MainApp

-- Import the Greeter class
#section IMPORT
import greeter

#section DEFINE
-- Instantiate Greeter with constructor argument
var greeter Greeter "Awesome name"

#section CODE
-- Call instance method
greeter.greet
```

**Syntax explanation:**
- `(private)` — Access modifier for class members
- `my.name` — Reference to instance variable
- `cvar` — Change/assign variable value
- `/` — Assignment operator
- `$...%` — Code block delimiters

### Importing Modules

Unlike butters, marg by convention groups dynamic and static imports into the IMPORT section:

```butters
#section META
*project MyApp

#section IMPORT
import utils
import math

#section DEFINE
var result          -- Declare result variable

#section CODE
-- Assign (cvar) result with utils.process applied to math.sqrt(16)
cvar result / utils.process math.sqrt(16)
```

**Syntax explanation:**
- `import` — Load external module/file
- `cvar x / value` — Assign value to variable x
- `utils.process()` — Call function from imported module

## Comparison

| Feature | Butters | marg |
|---------|---------|------|
| Section-based structure | ✓ | ✓ |
| Variable definitions | ✓ | ✓ |
| Dynamic imports | ✓ | ✓ |
| Classes & OOP | ✗ | ✓ |
| Enhanced module system | ✗ | ✓ |
| Type inference by value | ✗ | ✓ |
| Full backward compatibility | — | ✓ |

## File Extensions

- `.marg` — marg source files
- `.btrs` — butters source files that are also supported
- `.m` — Compiled marg intermediate representation

## Compiler Usage

```bash
# Compile to .m
marg compile main.marg -o app.m

# Assemble .m to executable
marg assemble app.m -o app

# Compile and assemble in one step
marg make main.marg -o app

# Compile, assemble, and run in one step, uses app as default name but -o can be specified
marg run main.marg
```

## Contributing

Contributions are welcome! Please feel free to submit pull requests or open issues.

## License

GPL-3.0 (same as butters)

## Related Projects

- [butters](https://github.com/riley0122/butters/) — The foundation language that marg extends
