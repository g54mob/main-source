using System.IO;

namespace HandlebarsDotNet
{
	public delegate string HandlebarsTemplate<in TContext, in TData>(TContext context, TData data = null) where TContext : class where TData : class;
	public delegate void HandlebarsTemplate<in TWriter, in TContext, in TData>(TWriter writer, TContext context, TData data = null) where TWriter : TextWriter where TContext : class where TData : class;
}
