using System;
using System.Threading;
using System.Xml;

namespace Castle.Components.DictionaryAdapter.Xml
{
	public class XmlSubtreeWriter : XmlWriter
	{
		private readonly IXmlNode node;

		private XmlWriter rootWriter;

		private XmlWriter childWriter;

		private WriteState state;

		private int depth;

		private XmlWriter RootWriter => rootWriter ?? (rootWriter = node.WriteAttributes());

		private XmlWriter ChildWriter => childWriter ?? (childWriter = node.WriteChildren());

		private bool IsInRootAttribute => state == WriteState.Attribute;

		private bool IsInRoot => depth > 0;

		private bool IsInChild => depth > 1;

		public override WriteState WriteState
		{
			get
			{
				if (!IsInRoot || state != WriteState.Content)
				{
					return state;
				}
				return childWriter.WriteState;
			}
		}

		public XmlSubtreeWriter(IXmlNode node)
		{
			if (node == null)
			{
				throw Error.ArgumentNull("node");
			}
			this.node = node;
		}

		protected override void Dispose(bool managed)
		{
			try
			{
				if (managed)
				{
					Reset(WriteState.Closed);
					DisposeWriter(ref rootWriter);
					DisposeWriter(ref childWriter);
				}
			}
			finally
			{
				base.Dispose(managed);
			}
		}

		private void DisposeWriter(ref XmlWriter writer)
		{
			Interlocked.Exchange(ref writer, null)?.Close();
		}

		public override void WriteStartDocument(bool standalone)
		{
			WriteStartDocument();
		}

		public override void WriteStartDocument()
		{
			RequireState(WriteState.Start);
			state = WriteState.Prolog;
		}

		public override void WriteDocType(string name, string pubid, string sysid, string subset)
		{
			RequireState(WriteState.Start, WriteState.Prolog);
			state = WriteState.Prolog;
		}

		public override void WriteStartElement(string prefix, string localName, string ns)
		{
			try
			{
				if (IsInRoot)
				{
					ChildWriter.WriteStartElement(prefix, localName, ns);
					state = WriteState.Content;
				}
				else
				{
					RequireState(WriteState.Start, WriteState.Prolog);
					node.Clear();
					state = WriteState.Element;
				}
				depth++;
			}
			catch
			{
				Reset(WriteState.Error);
				throw;
			}
		}

		private void WriteEndElement(Action<XmlWriter> action)
		{
			try
			{
				if (IsInChild)
				{
					action(ChildWriter);
					state = WriteState.Content;
				}
				else
				{
					RequireState(WriteState.Element, WriteState.Content);
					state = WriteState.Prolog;
				}
				depth--;
			}
			catch
			{
				Reset(WriteState.Error);
				throw;
			}
		}

		public override void WriteEndElement()
		{
			WriteEndElement(delegate(XmlWriter w)
			{
				w.WriteEndElement();
			});
		}

		public override void WriteFullEndElement()
		{
			WriteEndElement(delegate(XmlWriter w)
			{
				w.WriteFullEndElement();
			});
		}

		private void WriteAttribute(Action<XmlWriter> action, WriteState entryState, WriteState exitState)
		{
			try
			{
				if (IsInChild)
				{
					action(ChildWriter);
					return;
				}
				RequireState(entryState);
				action(RootWriter);
				state = exitState;
			}
			catch
			{
				Reset(WriteState.Error);
				throw;
			}
		}

		public override void WriteStartAttribute(string prefix, string localName, string ns)
		{
			WriteAttribute(delegate(XmlWriter w)
			{
				w.WriteStartAttribute(prefix, localName, ns);
			}, WriteState.Element, WriteState.Attribute);
		}

		public override void WriteEndAttribute()
		{
			WriteAttribute(delegate(XmlWriter w)
			{
				w.WriteEndAttribute();
			}, WriteState.Attribute, WriteState.Element);
		}

		private void WriteElementOrAttributeContent(Action<XmlWriter> action)
		{
			try
			{
				if (IsInChild)
				{
					action(ChildWriter);
					return;
				}
				if (IsInRootAttribute)
				{
					action(RootWriter);
					return;
				}
				RequireState(WriteState.Element, WriteState.Content);
				action(ChildWriter);
				state = WriteState.Content;
			}
			catch
			{
				Reset(WriteState.Error);
				throw;
			}
		}

		public override void WriteString(string text)
		{
			WriteElementOrAttributeContent(delegate(XmlWriter w)
			{
				w.WriteString(text);
			});
		}

		public override void WriteCharEntity(char ch)
		{
			WriteElementOrAttributeContent(delegate(XmlWriter w)
			{
				w.WriteCharEntity(ch);
			});
		}

		public override void WriteSurrogateCharEntity(char lowChar, char highChar)
		{
			WriteElementOrAttributeContent(delegate(XmlWriter w)
			{
				w.WriteSurrogateCharEntity(lowChar, highChar);
			});
		}

		public override void WriteEntityRef(string name)
		{
			WriteElementOrAttributeContent(delegate(XmlWriter w)
			{
				w.WriteEntityRef(name);
			});
		}

		public override void WriteChars(char[] buffer, int index, int count)
		{
			WriteElementOrAttributeContent(delegate(XmlWriter w)
			{
				w.WriteChars(buffer, index, count);
			});
		}

		public override void WriteBase64(byte[] buffer, int index, int count)
		{
			WriteElementOrAttributeContent(delegate(XmlWriter w)
			{
				w.WriteBase64(buffer, index, count);
			});
		}

		public override void WriteRaw(string data)
		{
			WriteElementOrAttributeContent(delegate(XmlWriter w)
			{
				w.WriteRaw(data);
			});
		}

		public override void WriteRaw(char[] buffer, int index, int count)
		{
			WriteElementOrAttributeContent(delegate(XmlWriter w)
			{
				w.WriteRaw(buffer, index, count);
			});
		}

		private void WriteElementContent(Action<XmlWriter> action)
		{
			try
			{
				RequireState(WriteState.Element, WriteState.Content);
				action(ChildWriter);
				state = WriteState.Content;
			}
			catch
			{
				Reset(WriteState.Error);
				throw;
			}
		}

		public override void WriteCData(string text)
		{
			WriteElementContent(delegate(XmlWriter w)
			{
				w.WriteCData(text);
			});
		}

		public override void WriteProcessingInstruction(string name, string text)
		{
			WriteElementContent(delegate(XmlWriter w)
			{
				w.WriteProcessingInstruction(name, text);
			});
		}

		public override void WriteComment(string text)
		{
			WriteElementContent(delegate(XmlWriter w)
			{
				w.WriteComment(text);
			});
		}

		public override void WriteWhitespace(string ws)
		{
			WriteElementContent(delegate(XmlWriter w)
			{
				w.WriteWhitespace(ws);
			});
		}

		private void WithWriters(Action<XmlWriter> action, bool worksIfClosed = false, WriteState? resetTo = null)
		{
			try
			{
				if (!worksIfClosed)
				{
					RequireNotClosed();
				}
				if (rootWriter != null)
				{
					action(rootWriter);
				}
				if (childWriter != null)
				{
					action(childWriter);
				}
				if (resetTo.HasValue)
				{
					Reset(resetTo.Value);
				}
			}
			catch
			{
				Reset(WriteState.Error);
				throw;
			}
		}

		public override void Flush()
		{
			WithWriters(delegate(XmlWriter w)
			{
				w.Flush();
			});
		}

		public override void WriteEndDocument()
		{
			WithWriters(delegate(XmlWriter w)
			{
				w.WriteEndDocument();
			}, worksIfClosed: false, WriteState.Start);
		}

		public override void Close()
		{
			WithWriters(delegate(XmlWriter w)
			{
				w.Close();
			}, worksIfClosed: true, WriteState.Closed);
		}

		public override string LookupPrefix(string ns)
		{
			try
			{
				string text;
				return (childWriter != null && (text = childWriter.LookupPrefix(ns)) != null) ? text : ((rootWriter != null && (text = rootWriter.LookupPrefix(ns)) != null) ? text : null);
			}
			catch
			{
				Reset(WriteState.Error);
				throw;
			}
		}

		private void RequireNotClosed()
		{
			if (state == WriteState.Closed || state == WriteState.Error)
			{
				throw Error.InvalidOperation();
			}
		}

		private void RequireState(WriteState state)
		{
			if (this.state != state)
			{
				throw Error.InvalidOperation();
			}
		}

		private void RequireState(WriteState state1, WriteState state2)
		{
			if (state != state1 && state != state2)
			{
				throw Error.InvalidOperation();
			}
		}

		private void Reset(WriteState state)
		{
			depth = 0;
			this.state = state;
		}
	}
}
