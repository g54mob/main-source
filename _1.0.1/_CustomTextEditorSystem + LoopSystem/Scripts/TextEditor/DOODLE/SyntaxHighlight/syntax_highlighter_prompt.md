# Unity Syntax Highlighter - Comprehensive Implementation Prompt

Use this prompt to generate a complete syntax highlighting system for Unity text editors.

---

## Context & Requirements

I need a **twin-layer overlay syntax highlighter** for a Unity text editor (Unity 2020.3+, .NET 2.0 compatible). The system should:

1. Use **two TextMeshPro components**:
   - **Source layer**: Plain text without formatting (the actual editable text)
   - **Overlay layer**: Rich text with color tags (visual highlighting only)

2. Be **extensible** via abstract base class for different languages

3. Use **regex-based pattern matching** with configurable color schemes

4. Handle **all edge cases** to prevent recursive highlighting bugs

---

## Technical Architecture

### Base Class: `SyntaxHighlighterBase.cs`

```csharp
public abstract class SyntaxHighlighterBase : MonoBehaviour
{
    [SerializeField] protected TextMeshPro sourceText;        // Plain text
    [SerializeField] protected TextMeshPro syntaxOverlayText; // Rich text overlay
    [SerializeField] protected bool enableHighlighting = true;
    
    // Public API
    public virtual void UpdateSyntaxVisual()
    {
        if (!enableHighlighting || sourceText == null || syntaxOverlayText == null)
            return;
            
        string plainText = sourceText.text;
        string highlightedText = ApplySyntaxHighlighting(plainText);
        syntaxOverlayText.text = highlightedText;
    }
    
    // Override this for language-specific highlighting
    protected abstract string ApplySyntaxHighlighting(string plainText);
    
    // Utility: Wrap text with TMP color tag
    protected string ColorWrap(string text, string hexColor)
    {
        return $"<color=#{hexColor}>{text}</color>";
    }
}
```

### Concrete Implementation: `PythonSyntaxHighlighter.cs`

Implement Python-like syntax with these features:

**Syntax Elements** (in order of precedence):
1. **Comments** - `#` to end of line (including inline comments)
2. **Strings** - Single `'`, double `"`, triple `'''` or `"""`
3. **Numbers** - Int, float, hex (`0x`), binary (`0b`), octal (`0o`), scientific notation
4. **Keywords** - `def`, `if`, `else`, `return`, `True`, `False`, etc.
5. **Built-in functions** - `print()`, `len()`, `range()`, etc.
6. **Custom identifiers** - User-defined types/functions (configurable via Inspector)
7. **Operators** - `+`, `-`, `*`, `/`, `=`, `==`, `<`, `>`, etc.

**Color Scheme** (Claude Dark Theme):
```csharp
commentColor = "6B7280"      // Gray
keywordColor = "C084FC"      // Purple
stringColor = "34D399"       // Green
numberColor = "60A5FA"       // Blue
operatorColor = "F472B6"     // Pink
builtinColor = "FBBF24"      // Amber
customBuiltinColor = "FB923C" // Orange
```

---

## CRITICAL: Edge Case Handling

### Problem: Recursive Highlighting

When highlighting operators like `=`, `<`, `>`, these characters exist inside color tags themselves:
```
<color=#6B7280>text</color>
       ↑ This '=' must NOT be highlighted!
```

### Solution: Placeholder Protection System

**Implementation Pattern**:
```csharp
private Dictionary<string, string> protectedContent = new Dictionary<string, string>();
private int placeholderCounter = 0;

protected override string ApplySyntaxHighlighting(string plainText)
{
    protectedContent.Clear();
    placeholderCounter = 0;
    
    string result = plainText;
    
    // Apply highlighting with protection
    result = ApplyAndProtect(result, HighlightComments);
    result = ApplyAndProtect(result, HighlightStrings);
    result = ApplyAndProtect(result, HighlightNumbers);
    result = ApplyAndProtect(result, HighlightKeywords);
    result = ApplyAndProtect(result, HighlightBuiltins);
    result = ApplyAndProtect(result, HighlightCustomBuiltins);
    
    // CRITICAL: Operators need special handling
    result = HighlightOperatorsWithProtection(result);
    
    // Restore all placeholders
    result = RestoreProtectedContent(result);
    
    return result;
}

private string ApplyAndProtect(string text, Func<string, string> highlightFunc)
{
    text = highlightFunc(text);
    text = ProtectColorTags(text);
    return text;
}

private string ProtectColorTags(string text)
{
    // Replace color tags with unique placeholders using control characters
    return Regex.Replace(text, @"<color=#[0-9A-Fa-f]{6}>.*?</color>", match =>
    {
        string placeholder = $"\x02PLACEHOLDER_{placeholderCounter}\x03";
        protectedContent[placeholder] = match.Value;
        placeholderCounter++;
        return placeholder;
    }, RegexOptions.Singleline);
}

private string RestoreProtectedContent(string text)
{
    foreach (var kvp in protectedContent)
    {
        text = text.Replace(kvp.Key, kvp.Value);
    }
    return text;
}
```

### Why This Works

1. **Control characters** (`\x02`, `\x03`) never appear in code
2. **Placeholders** don't match any syntax patterns
3. **Each highlighting step** sees only placeholders, never `<color>` tags
4. **Final restoration** brings back all color tags at once

### Special Case: Operators

Operators MUST be handled differently because multiple operator types can match the same characters:

```csharp
private string HighlightOperatorsWithProtection(string text)
{
    string[] operators = new string[]
    {
        @"\*\*", @"//", @"<<", @">>", // Longest first
        @"==", @"!=", @"<=", @">=",
        @"\+=", @"-=", @"\*=", @"/=", @"%=",
        @"\+", @"-", @"\*", @"/", @"%",
        @"<", @">", @"=",
        @"&", @"\|", @"\^", @"~", @"@"
    };
    
    // CRITICAL: Protect after EACH operator!
    foreach (string op in operators)
    {
        text = Regex.Replace(text, op, match => ColorWrap(match.Value, operatorColor));
        text = ProtectColorTags(text); // ← Immediate protection!
    }
    
    return text;
}
```

**Why immediate protection?**
- When highlighting `=`, text may already contain `<color=#89DDFF>+</color>` from previous `+` operator
- Without protection, `=` regex matches the `=` in `<color=#...>`, creating nested tags
- Immediate protection converts `<color=#89DDFF>+</color>` → `\x02PLACEHOLDER_5\x03` before processing next operator

---

## Pattern Matching Guidelines

### Comments
```csharp
string pattern = @"(#.*)(?=\n|$)";
// Matches from # to end of line
```

### Strings
```csharp
// Order matters: triple quotes first!
@"(""""""[\s\S]*?"""""")"  // Triple double
@"('''[\s\S]*?''')"        // Triple single
@"(""(?:[^""\\]|\\.)*"")"  // Double quote
@"('(?:[^'\\]|\\.)*')"     // Single quote
```

### Numbers
```csharp
@"\b(0x[0-9A-Fa-f]+|0b[01]+|0o[0-7]+|\d+\.?\d*(?:[eE][+-]?\d+)?)\b"
// Hex, binary, octal, int, float, scientific
```

### Keywords
```csharp
@"\b" + Regex.Escape(keyword) + @"\b"
// Word boundaries prevent partial matches
```

### Built-ins (Function Calls)
```csharp
@"\b" + Regex.Escape(builtin) + @"(?=\s*\()"
// Only highlight if followed by '('
```

---

## Unity Setup Checklist

### GameObject Structure
```
TextEditorContainer
├── SourceText (TextMeshPro)
│   ├── Font: Consolas Bold, Size: 16
│   ├── Color: #1F2937 (dim gray)
│   ├── Rich Text: DISABLED
│   └── Position: (0, 0, 0)
└── SyntaxOverlay (TextMeshPro)
    ├── Font: Consolas Bold, Size: 16
    ├── Color: #FFFFFF (white)
    ├── Rich Text: ENABLED
    └── Position: (0, 0, -0.1) ← Slightly forward
```

### Script Configuration
```csharp
// On TextEditor component
[SerializeField] SyntaxHighlighterBase syntaxHighlighter;

// Call this whenever text changes
void UpdateEntireDisplayVisual()
{
    _textField.text = GetCurrentText();
    
    if (syntaxHighlighter != null)
        syntaxHighlighter.UpdateSyntaxVisual();
}
```

---

## Testing & Validation

### Debug Tools (Context Menu)
```csharp
[ContextMenu("Test Simple Case")]
private void TestSimpleCase()
{
    string testCode = "# comment\na = b + c";
    sourceText.text = testCode;
    UpdateSyntaxVisual();
    
    // Validate output
    if (syntaxOverlayText.text.Contains("<color<color"))
        Debug.LogError("❌ NESTED TAGS DETECTED!");
    else
        Debug.Log("✓ Highlighting correct!");
}
```

### Common Test Cases
```python
# Test 1: Comments
# This is a comment
x = 5  # Inline comment

# Test 2: Strings
s1 = 'single'
s2 = "double"
s3 = '''triple
multi-line'''

# Test 3: Operators in sequence
a = b + c * d / e - f ** g // h

# Test 4: Edge case - operators in strings
text = "a = b + c"  # Should NOT highlight operators in string
```

---

## Performance Considerations

### For Large Files (1000+ lines)
- **Viewport rendering**: Only highlight visible lines
- **Debouncing**: Delay highlighting by 100-200ms after typing stops
- **Caching**: Store regex patterns as static compiled patterns
- **Profiling**: Use Unity Profiler to check `Regex.Replace` performance

### Optimization Pattern
```csharp
// Cache compiled regex patterns
private static Regex commentPattern = new Regex(@"(#.*)(?=\n|$)", RegexOptions.Compiled);

private string HighlightComments(string text)
{
    return commentPattern.Replace(text, match => ColorWrap(match.Value, commentColor));
}
```

---

## Extension Examples

### C# Syntax Highlighter
```csharp
public class CSharpSyntaxHighlighter : SyntaxHighlighterBase
{
    protected override string ApplySyntaxHighlighting(string plainText)
    {
        // Similar pattern but with C# rules
        result = ApplyAndProtect(result, HighlightCSharpComments);
        result = ApplyAndProtect(result, HighlightCSharpStrings);
        result = ApplyAndProtect(result, HighlightTypes);
        // ... etc
    }
    
    private string HighlightTypes(string text)
    {
        // Highlight int, string, bool, etc.
        string[] types = { "int", "string", "bool", "float", "void" };
        foreach (string type in types)
        {
            text = Regex.Replace(text, @"\b" + type + @"\b", 
                match => ColorWrap(match.Value, typeColor));
        }
        return text;
    }
}
```

### JSON Syntax Highlighter
```csharp
public class JsonSyntaxHighlighter : SyntaxHighlighterBase
{
    protected override string ApplySyntaxHighlighting(string plainText)
    {
        result = ApplyAndProtect(result, HighlightJsonKeys);
        result = ApplyAndProtect(result, HighlightJsonStrings);
        result = ApplyAndProtect(result, HighlightJsonNumbers);
        result = ApplyAndProtect(result, HighlightJsonBooleans);
        return RestoreProtectedContent(result);
    }
}
```

---

## Summary: Key Rules for ANY Language

1. **Always use placeholder protection** to prevent recursive highlighting
2. **Process in order of precedence**: Comments → Strings → Numbers → Keywords → Operators
3. **Protect operators specially**: One-by-one with immediate protection
4. **Use word boundaries** (`\b`) for keyword/identifier matching
5. **Test edge cases**: Operators in strings, nested structures, special characters
6. **Profile performance**: Cache regex patterns, consider viewport rendering for large files

This pattern works for **any programming language** - just adjust the syntax rules and patterns!