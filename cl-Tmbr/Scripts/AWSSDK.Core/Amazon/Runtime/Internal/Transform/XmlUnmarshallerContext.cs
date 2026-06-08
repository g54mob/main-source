using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Xml;
using Amazon.Runtime.Internal.Util;

namespace Amazon.Runtime.Internal.Transform
{
	public class XmlUnmarshallerContext : UnmarshallerContext
	{
		private static HashSet<XmlNodeType> nodesToSkip = new HashSet<XmlNodeType>
		{
			XmlNodeType.None,
			XmlNodeType.XmlDeclaration,
			XmlNodeType.Comment,
			XmlNodeType.DocumentType,
			XmlNodeType.CDATA,
			XmlNodeType.Whitespace
		};

		private StreamReader streamReader;

		private XmlTextReader _xmlTextReader;

		private Stack<string> stack = new Stack<string>();

		private string stackString = "";

		private Dictionary<string, string> attributeValues;

		private List<string> attributeNames;

		private IEnumerator<string> attributeEnumerator;

		private XmlNodeType nodeType;

		private string nodeContent = string.Empty;

		private bool disposed;

		private bool currentlyProcessingEmptyElement;

		public Stream Stream => streamReader.BaseStream;

		private XmlTextReader XmlReader
		{
			get
			{
				if (_xmlTextReader == null)
				{
					_xmlTextReader = new XmlTextReader(streamReader);
					_xmlTextReader.WhitespaceHandling = WhitespaceHandling.All;
					_xmlTextReader.DtdProcessing = DtdProcessing.Ignore;
				}
				return _xmlTextReader;
			}
		}

		public override string CurrentPath => stackString;

		public override int CurrentDepth => stack.Count;

		public override bool IsStartElement => nodeType == XmlNodeType.Element;

		public override bool IsEndElement => nodeType == XmlNodeType.EndElement;

		public override bool IsStartOfDocument => XmlReader.ReadState == ReadState.Initial;

		public bool IsAttribute => nodeType == XmlNodeType.Attribute;

		public XmlUnmarshallerContext(Stream responseStream, bool maintainResponseBody, IWebResponseData responseData, bool isException = false)
			: this(responseStream, maintainResponseBody, responseData, isException, null)
		{
		}

		public XmlUnmarshallerContext(Stream responseStream, bool maintainResponseBody, IWebResponseData responseData, bool isException, IRequestContext requestContext)
		{
			if (isException)
			{
				base.WrappingStream = new CachingWrapperStream(responseStream);
			}
			else if (maintainResponseBody)
			{
				base.WrappingStream = new CachingWrapperStream(responseStream, AWSConfigs.LoggingConfig.LogResponsesSizeLimit);
			}
			if (isException || maintainResponseBody)
			{
				responseStream = base.WrappingStream;
			}
			if (responseData != null)
			{
				long result;
				bool num = long.TryParse(responseData.GetHeaderValue("Content-Length"), out result);
				if (num && result == 0L)
				{
					base.IsEmptyResponse = true;
				}
				if (num && responseData.ContentLength == result && string.IsNullOrEmpty(responseData.GetHeaderValue("Content-Encoding")) && requestContext != null && requestContext.OriginalRequest?.CoreChecksumMode == CoreChecksumResponseBehavior.ENABLED)
				{
					SetupFlexibleChecksumStream(responseData, responseStream, result, requestContext);
				}
			}
			streamReader = new StreamReader(base.FlexibleChecksumStream ?? responseStream);
			base.WebResponseData = responseData;
			base.MaintainResponseBody = maintainResponseBody;
			base.IsException = isException;
		}

		public string ReadText()
		{
			if (nodeType == XmlNodeType.Attribute)
			{
				return attributeValues[attributeEnumerator.Current];
			}
			return nodeContent;
		}

		public bool ReadAtDepth(int targetDepth)
		{
			if (Read())
			{
				return CurrentDepth >= targetDepth;
			}
			return false;
		}

		public virtual bool Read()
		{
			if (attributeEnumerator != null && attributeEnumerator.MoveNext())
			{
				nodeType = XmlNodeType.Attribute;
				stackString = string.Format(CultureInfo.InvariantCulture, "{0}/@{1}", StackToPath(stack), attributeEnumerator.Current);
			}
			else
			{
				if (nodesToSkip.Contains(XmlReader.NodeType))
				{
					XmlReader.Read();
				}
				if (currentlyProcessingEmptyElement)
				{
					nodeType = XmlNodeType.EndElement;
					stack.Pop();
					stackString = StackToPath(stack);
					XmlReader.Read();
					currentlyProcessingEmptyElement = false;
				}
				else if (XmlReader.IsEmptyElement)
				{
					nodeType = XmlNodeType.Element;
					stack.Push(XmlReader.LocalName);
					stackString = StackToPath(stack);
					currentlyProcessingEmptyElement = true;
					nodeContent = string.Empty;
				}
				else
				{
					switch (XmlReader.NodeType)
					{
					case XmlNodeType.EndElement:
						nodeType = XmlNodeType.EndElement;
						stack.Pop();
						stackString = StackToPath(stack);
						XmlReader.Read();
						break;
					case XmlNodeType.Element:
						nodeType = XmlNodeType.Element;
						stack.Push(XmlReader.LocalName);
						stackString = StackToPath(stack);
						ReadElement();
						break;
					}
				}
			}
			if (XmlReader.ReadState != ReadState.EndOfFile && XmlReader.ReadState != ReadState.Error)
			{
				return XmlReader.ReadState != ReadState.Closed;
			}
			return false;
		}

		private static string StackToPath(Stack<string> stack)
		{
			string text = null;
			string[] array = stack.ToArray();
			foreach (string text2 in array)
			{
				text = ((text == null) ? text2 : string.Format(CultureInfo.InvariantCulture, "{0}/{1}", text2, text));
			}
			return "/" + text;
		}

		private void ReadElement()
		{
			if (XmlReader.HasAttributes)
			{
				attributeValues = new Dictionary<string, string>();
				attributeNames = new List<string>();
				while (XmlReader.MoveToNextAttribute())
				{
					attributeValues.Add(XmlReader.LocalName, XmlReader.Value);
					attributeNames.Add(XmlReader.LocalName);
				}
				attributeEnumerator = attributeNames.GetEnumerator();
			}
			XmlReader.MoveToElement();
			XmlReader.Read();
			if (XmlReader.NodeType == XmlNodeType.Text || XmlReader.NodeType == XmlNodeType.Whitespace)
			{
				nodeContent = XmlReader.ReadContentAsString();
			}
			else
			{
				nodeContent = string.Empty;
			}
		}

		protected override void Dispose(bool disposing)
		{
			if (!disposed)
			{
				if (disposing)
				{
					if (streamReader != null)
					{
						streamReader.Dispose();
						streamReader = null;
					}
					if (_xmlTextReader != null)
					{
						_xmlTextReader.Dispose();
						_xmlTextReader = null;
					}
				}
				disposed = true;
			}
			base.Dispose(disposing);
		}
	}
}
