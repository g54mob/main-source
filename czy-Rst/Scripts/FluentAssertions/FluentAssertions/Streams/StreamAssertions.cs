using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using FluentAssertions.Execution;
using FluentAssertions.Primitives;

namespace FluentAssertions.Streams
{
	[DebuggerNonUserCode]
	public class StreamAssertions : StreamAssertions<Stream, StreamAssertions>
	{
		public StreamAssertions(Stream stream, AssertionChain assertionChain)
			: base(stream, assertionChain)
		{
		}
	}
	public class StreamAssertions<TSubject, TAssertions> : ReferenceTypeAssertions<TSubject, TAssertions> where TSubject : Stream where TAssertions : StreamAssertions<TSubject, TAssertions>
	{
		private readonly AssertionChain assertionChain;

		protected override string Identifier => "stream";

		public StreamAssertions(TSubject stream, AssertionChain assertionChain)
			: base(stream, assertionChain)
		{
			this.assertionChain = assertionChain;
		}

		public AndConstraint<TAssertions> BeWritable([StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			assertionChain.BecauseOf(because, becauseArgs).ForCondition(base.Subject != null).FailWith("Expected {context:stream} to be writable{reason}, but found a <null> reference.");
			if (assertionChain.Succeeded)
			{
				assertionChain.BecauseOf(because, becauseArgs).ForCondition(base.Subject.CanWrite).FailWith("Expected {context:stream} to be writable{reason}, but it was not.");
			}
			return new AndConstraint<TAssertions>((TAssertions)this);
		}

		public AndConstraint<TAssertions> NotBeWritable([StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			assertionChain.BecauseOf(because, becauseArgs).ForCondition(base.Subject != null).FailWith("Expected {context:stream} not to be writable{reason}, but found a <null> reference.");
			if (assertionChain.Succeeded)
			{
				assertionChain.BecauseOf(because, becauseArgs).ForCondition(!base.Subject.CanWrite).FailWith("Expected {context:stream} not to be writable{reason}, but it was.");
			}
			return new AndConstraint<TAssertions>((TAssertions)this);
		}

		public AndConstraint<TAssertions> BeSeekable([StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			assertionChain.BecauseOf(because, becauseArgs).ForCondition(base.Subject != null).FailWith("Expected {context:stream} to be seekable{reason}, but found a <null> reference.");
			if (assertionChain.Succeeded)
			{
				assertionChain.BecauseOf(because, becauseArgs).ForCondition(base.Subject.CanSeek).FailWith("Expected {context:stream} to be seekable{reason}, but it was not.");
			}
			return new AndConstraint<TAssertions>((TAssertions)this);
		}

		public AndConstraint<TAssertions> NotBeSeekable([StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			assertionChain.BecauseOf(because, becauseArgs).ForCondition(base.Subject != null).FailWith("Expected {context:stream} not to be seekable{reason}, but found a <null> reference.");
			if (assertionChain.Succeeded)
			{
				assertionChain.BecauseOf(because, becauseArgs).ForCondition(!base.Subject.CanSeek).FailWith("Expected {context:stream} not to be seekable{reason}, but it was.");
			}
			return new AndConstraint<TAssertions>((TAssertions)this);
		}

		public AndConstraint<TAssertions> BeReadable([StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			assertionChain.BecauseOf(because, becauseArgs).ForCondition(base.Subject != null).FailWith("Expected {context:stream} to be readable{reason}, but found a <null> reference.");
			if (assertionChain.Succeeded)
			{
				assertionChain.BecauseOf(because, becauseArgs).ForCondition(base.Subject.CanRead).FailWith("Expected {context:stream} to be readable{reason}, but it was not.");
			}
			return new AndConstraint<TAssertions>((TAssertions)this);
		}

		public AndConstraint<TAssertions> NotBeReadable([StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			assertionChain.BecauseOf(because, becauseArgs).ForCondition(base.Subject != null).FailWith("Expected {context:stream} not to be readable{reason}, but found a <null> reference.");
			if (assertionChain.Succeeded)
			{
				assertionChain.BecauseOf(because, becauseArgs).ForCondition(!base.Subject.CanRead).FailWith("Expected {context:stream} not to be readable{reason}, but it was.");
			}
			return new AndConstraint<TAssertions>((TAssertions)this);
		}

		public AndConstraint<TAssertions> HavePosition(long expected, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			assertionChain.BecauseOf(because, becauseArgs).ForCondition(base.Subject != null).FailWith("Expected the position of {context:stream} to be {0}{reason}, but found a <null> reference.", expected);
			if (assertionChain.Succeeded)
			{
				long position;
				try
				{
					position = base.Subject.Position;
				}
				catch (Exception ex) when (((ex is IOException || ex is NotSupportedException || ex is ObjectDisposedException) ? 1 : 0) != 0)
				{
					assertionChain.BecauseOf(because, becauseArgs).FailWith("Expected the position of {context:stream} to be {0}{reason}, but it failed with:" + Environment.NewLine + "{1}", expected, ex.Message);
					return new AndConstraint<TAssertions>((TAssertions)this);
				}
				assertionChain.BecauseOf(because, becauseArgs).ForCondition(position == expected).FailWith("Expected the position of {context:stream} to be {0}{reason}, but it was {1}.", expected, position);
			}
			return new AndConstraint<TAssertions>((TAssertions)this);
		}

		public AndConstraint<TAssertions> NotHavePosition(long unexpected, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			assertionChain.BecauseOf(because, becauseArgs).ForCondition(base.Subject != null).FailWith("Expected the position of {context:stream} not to be {0}{reason}, but found a <null> reference.", unexpected);
			if (assertionChain.Succeeded)
			{
				long position;
				try
				{
					position = base.Subject.Position;
				}
				catch (Exception ex) when (((ex is IOException || ex is NotSupportedException || ex is ObjectDisposedException) ? 1 : 0) != 0)
				{
					assertionChain.BecauseOf(because, becauseArgs).FailWith("Expected the position of {context:stream} not to be {0}{reason}, but it failed with:" + Environment.NewLine + "{1}", unexpected, ex.Message);
					return new AndConstraint<TAssertions>((TAssertions)this);
				}
				assertionChain.BecauseOf(because, becauseArgs).ForCondition(position != unexpected).FailWith("Expected the position of {context:stream} not to be {0}{reason}, but it was.", unexpected);
			}
			return new AndConstraint<TAssertions>((TAssertions)this);
		}

		public AndConstraint<TAssertions> HaveLength(long expected, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			assertionChain.BecauseOf(because, becauseArgs).ForCondition(base.Subject != null).FailWith("Expected the length of {context:stream} to be {0}{reason}, but found a <null> reference.", expected);
			if (assertionChain.Succeeded)
			{
				long length;
				try
				{
					length = base.Subject.Length;
				}
				catch (Exception ex) when (((ex is IOException || ex is NotSupportedException || ex is ObjectDisposedException) ? 1 : 0) != 0)
				{
					assertionChain.BecauseOf(because, becauseArgs).FailWith("Expected the length of {context:stream} to be {0}{reason}, but it failed with:" + Environment.NewLine + "{1}", expected, ex.Message);
					return new AndConstraint<TAssertions>((TAssertions)this);
				}
				assertionChain.BecauseOf(because, becauseArgs).ForCondition(length == expected).FailWith("Expected the length of {context:stream} to be {0}{reason}, but it was {1}.", expected, length);
			}
			return new AndConstraint<TAssertions>((TAssertions)this);
		}

		public AndConstraint<TAssertions> NotHaveLength(long unexpected, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			assertionChain.BecauseOf(because, becauseArgs).ForCondition(base.Subject != null).FailWith("Expected the length of {context:stream} not to be {0}{reason}, but found a <null> reference.", unexpected);
			if (assertionChain.Succeeded)
			{
				long length;
				try
				{
					length = base.Subject.Length;
				}
				catch (Exception ex) when (((ex is IOException || ex is NotSupportedException || ex is ObjectDisposedException) ? 1 : 0) != 0)
				{
					assertionChain.BecauseOf(because, becauseArgs).FailWith("Expected the length of {context:stream} not to be {0}{reason}, but it failed with:" + Environment.NewLine + "{1}", unexpected, ex.Message);
					return new AndConstraint<TAssertions>((TAssertions)this);
				}
				assertionChain.BecauseOf(because, becauseArgs).ForCondition(length != unexpected).FailWith("Expected the length of {context:stream} not to be {0}{reason}, but it was.", unexpected);
			}
			return new AndConstraint<TAssertions>((TAssertions)this);
		}

		public AndConstraint<TAssertions> BeReadOnly([StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			assertionChain.BecauseOf(because, becauseArgs).ForCondition(base.Subject != null).FailWith("Expected {context:stream} to be read-only{reason}, but found a <null> reference.");
			if (assertionChain.Succeeded)
			{
				assertionChain.BecauseOf(because, becauseArgs).ForCondition(!base.Subject.CanWrite && base.Subject.CanRead).FailWith("Expected {context:stream} to be read-only{reason}, but it was writable or not readable.");
			}
			return new AndConstraint<TAssertions>((TAssertions)this);
		}

		public AndConstraint<TAssertions> NotBeReadOnly([StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			assertionChain.BecauseOf(because, becauseArgs).ForCondition(base.Subject != null).FailWith("Expected {context:stream} not to be read-only{reason}, but found a <null> reference.");
			if (assertionChain.Succeeded)
			{
				assertionChain.BecauseOf(because, becauseArgs).ForCondition(base.Subject.CanWrite || !base.Subject.CanRead).FailWith("Expected {context:stream} not to be read-only{reason}, but it was.");
			}
			return new AndConstraint<TAssertions>((TAssertions)this);
		}

		public AndConstraint<TAssertions> BeWriteOnly([StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			assertionChain.BecauseOf(because, becauseArgs).ForCondition(base.Subject != null).FailWith("Expected {context:stream} to be write-only{reason}, but found a <null> reference.");
			if (assertionChain.Succeeded)
			{
				assertionChain.BecauseOf(because, becauseArgs).ForCondition(base.Subject.CanWrite && !base.Subject.CanRead).FailWith("Expected {context:stream} to be write-only{reason}, but it was readable or not writable.");
			}
			return new AndConstraint<TAssertions>((TAssertions)this);
		}

		public AndConstraint<TAssertions> NotBeWriteOnly([StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			assertionChain.BecauseOf(because, becauseArgs).ForCondition(base.Subject != null).FailWith("Expected {context:stream} not to be write-only{reason}, but found a <null> reference.");
			if (assertionChain.Succeeded)
			{
				assertionChain.BecauseOf(because, becauseArgs).ForCondition(!base.Subject.CanWrite || base.Subject.CanRead).FailWith("Expected {context:stream} not to be write-only{reason}, but it was.");
			}
			return new AndConstraint<TAssertions>((TAssertions)this);
		}
	}
}
