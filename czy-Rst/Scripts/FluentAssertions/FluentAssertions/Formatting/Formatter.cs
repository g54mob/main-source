using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions.Common;
using FluentAssertions.Equivalency.Execution;
using FluentAssertions.Execution;
using FluentAssertions.Xml;

namespace FluentAssertions.Formatting
{
	public static class Formatter
	{
		private sealed class ObjectGraph
		{
			private readonly CyclicReferenceDetector tracker;

			private readonly Stack<string> pathStack;

			public int Depth => pathStack.Count - 1;

			public ObjectGraph(object rootObject)
			{
				tracker = new CyclicReferenceDetector();
				pathStack = new Stack<string>();
				TryPush("root", rootObject);
			}

			public bool TryPush(string path, object value)
			{
				pathStack.Push(path);
				string fullPath = GetFullPath();
				ObjectReference reference = new ObjectReference(value, fullPath);
				return !tracker.IsCyclicReference(reference);
			}

			private string GetFullPath()
			{
				return string.Join(".", pathStack.Reverse());
			}

			public void Pop()
			{
				pathStack.Pop();
			}

			public override string ToString()
			{
				return string.Join(".", pathStack.Reverse());
			}
		}

		private static readonly List<IValueFormatter> CustomFormatters = new List<IValueFormatter>();

		private static readonly List<IValueFormatter> DefaultFormatters = new List<IValueFormatter>(35)
		{
			new PassthroughValueFormatter(),
			new XmlReaderValueFormatter(),
			new XmlNodeFormatter(),
			new AttributeBasedFormatter(),
			new AggregateExceptionValueFormatter(),
			new XDocumentValueFormatter(),
			new XElementValueFormatter(),
			new XAttributeValueFormatter(),
			new PropertyInfoFormatter(),
			new MethodInfoFormatter(),
			new NullValueFormatter(),
			new GuidValueFormatter(),
			new DateTimeOffsetValueFormatter(),
			new TimeSpanValueFormatter(),
			new Int32ValueFormatter(),
			new Int64ValueFormatter(),
			new DoubleValueFormatter(),
			new SingleValueFormatter(),
			new DecimalValueFormatter(),
			new ByteValueFormatter(),
			new UInt32ValueFormatter(),
			new UInt64ValueFormatter(),
			new Int16ValueFormatter(),
			new UInt16ValueFormatter(),
			new SByteValueFormatter(),
			new StringValueFormatter(),
			new TaskFormatter(),
			new PredicateLambdaExpressionValueFormatter(),
			new ExpressionValueFormatter(),
			new ExceptionValueFormatter(),
			new MultidimensionalArrayFormatter(),
			new DictionaryValueFormatter(),
			new EnumerableValueFormatter(),
			new EnumValueFormatter(),
			new DefaultValueFormatter()
		};

		[ThreadStatic]
		private static bool isReentry;

		public static IEnumerable<IValueFormatter> Formatters => AssertionScope.Current.FormattingOptions.ScopedFormatters.Concat(CustomFormatters).Concat(DefaultFormatters);

		public static string ToString(object value, FormattingOptions options = null)
		{
			if (options == null)
			{
				options = new FormattingOptions();
			}
			try
			{
				if (isReentry)
				{
					throw new InvalidOperationException("Use the FormatChild delegate inside a IValueFormatter to recursively format children");
				}
				isReentry = true;
				ObjectGraph graph = new ObjectGraph(value);
				FormattingContext context = new FormattingContext
				{
					UseLineBreaks = options.UseLineBreaks
				};
				FormattedObjectGraph formattedObjectGraph = new FormattedObjectGraph(options.MaxLines);
				try
				{
					Format(value, formattedObjectGraph, context, delegate(string path, object childValue, FormattedObjectGraph childOutput)
					{
						FormatChild(path, childValue, childOutput, context, options, graph);
					});
				}
				catch (MaxLinesExceededException)
				{
				}
				return formattedObjectGraph.ToString();
			}
			finally
			{
				isReentry = false;
			}
		}

		private static void FormatChild(string path, object value, FormattedObjectGraph output, FormattingContext context, FormattingOptions options, ObjectGraph graph)
		{
			try
			{
				Guard.ThrowIfArgumentIsNullOrEmpty(path, "path", "Formatting a child value requires a path");
				if (!graph.TryPush(path, value))
				{
					output.AddFragment($"{{Cyclic reference to type {value.GetType()} detected}}");
					return;
				}
				if (graph.Depth > options.MaxDepth)
				{
					output.AddLine($"Maximum recursion depth of {options.MaxDepth} was reached. " + " Increase MaxDepth on AssertionScope or AssertionConfiguration to get more details.");
					return;
				}
				using (output.WithIndentation())
				{
					Format(value, output, context, delegate(string childPath, object childValue, FormattedObjectGraph nestedOutput)
					{
						FormatChild(childPath, childValue, nestedOutput, context, options, graph);
					});
				}
			}
			finally
			{
				graph.Pop();
			}
		}

		private static void Format(object value, FormattedObjectGraph output, FormattingContext context, FormatChild formatChild)
		{
			Formatters.First((IValueFormatter f) => f.CanHandle(value)).Format(value, output, context, formatChild);
		}

		public static void RemoveFormatter(IValueFormatter formatter)
		{
			CustomFormatters.Remove(formatter);
		}

		public static void AddFormatter(IValueFormatter formatter)
		{
			if (!CustomFormatters.Contains(formatter))
			{
				CustomFormatters.Insert(0, formatter);
			}
		}
	}
}
