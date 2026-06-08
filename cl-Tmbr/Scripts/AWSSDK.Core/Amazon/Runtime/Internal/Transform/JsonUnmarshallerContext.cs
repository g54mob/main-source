using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;
using Amazon.Runtime.Internal.Util;

namespace Amazon.Runtime.Internal.Transform
{
	public class JsonUnmarshallerContext : UnmarshallerContext
	{
		private enum PathSegmentType
		{
			Value = 0,
			Delimiter = 1
		}

		private struct PathSegment
		{
			internal PathSegmentType SegmentType { get; set; }

			internal string Value { get; set; }
		}

		private class JsonPathStack
		{
			private Stack<PathSegment> stack = new Stack<PathSegment>();

			private int currentDepth;

			private StringBuilder stackStringBuilder = new StringBuilder(128);

			private string stackString;

			public int CurrentDepth => currentDepth;

			public string CurrentPath
			{
				get
				{
					if (stackString == null)
					{
						stackString = stackStringBuilder.ToString();
					}
					return stackString;
				}
			}

			public int Count => stack.Count;

			internal void Push(PathSegment segment)
			{
				if (segment.SegmentType == PathSegmentType.Delimiter)
				{
					currentDepth++;
				}
				stackStringBuilder.Append(segment.Value);
				stackString = null;
				stack.Push(segment);
			}

			internal PathSegment Pop()
			{
				PathSegment result = stack.Pop();
				if (result.SegmentType == PathSegmentType.Delimiter)
				{
					currentDepth--;
				}
				stackStringBuilder.Remove(stackStringBuilder.Length - result.Value.Length, result.Value.Length);
				stackString = null;
				return result;
			}

			internal PathSegment Peek()
			{
				return stack.Peek();
			}
		}

		private const string DELIMITER = "/";

		private StreamReader streamReader;

		private JsonPathStack stack = new JsonPathStack();

		private JsonTokenType? currentToken;

		private bool disposed;

		private bool wasPeeked;

		public override bool IsStartOfDocument
		{
			get
			{
				if (CurrentTokenType == JsonTokenType.None)
				{
					return !streamReader.EndOfStream;
				}
				return false;
			}
		}

		public override bool IsEndElement => CurrentTokenType == JsonTokenType.EndObject;

		public override bool IsStartElement => CurrentTokenType == JsonTokenType.StartObject;

		public override int CurrentDepth => stack.CurrentDepth;

		public override string CurrentPath => stack.CurrentPath;

		public JsonTokenType? CurrentTokenType => currentToken;

		public Stream Stream => streamReader.BaseStream;

		public JsonUnmarshallerContext(Stream responseStream, bool maintainResponseBody, IWebResponseData responseData, bool isException = false)
			: this(responseStream, maintainResponseBody, responseData, isException, null)
		{
		}

		public JsonUnmarshallerContext(Stream responseStream, bool maintainResponseBody, IWebResponseData responseData, bool isException, IRequestContext requestContext)
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
			base.WebResponseData = responseData;
			base.MaintainResponseBody = maintainResponseBody;
			base.IsException = isException;
			if (responseData != null)
			{
				long result;
				bool num = long.TryParse(responseData.GetHeaderValue("Content-Length"), out result);
				if (num && result == 0L)
				{
					base.IsEmptyResponse = true;
				}
				if (num && responseData.ContentLength.Equals(result) && string.IsNullOrEmpty(responseData.GetHeaderValue("Content-Encoding")))
				{
					SetupCRCStream(responseData, responseStream, result);
					SetupFlexibleChecksumStream(responseData, base.CrcStream ?? responseStream, result, requestContext);
				}
			}
			if (base.FlexibleChecksumStream != null)
			{
				streamReader = new StreamReader(base.FlexibleChecksumStream);
			}
			else if (base.CrcStream != null)
			{
				streamReader = new StreamReader(base.CrcStream);
			}
			else
			{
				streamReader = new StreamReader(responseStream);
			}
		}

		public bool ReadAtDepth(int targetDepth, ref StreamingUtf8JsonReader reader)
		{
			if (Read(ref reader))
			{
				return CurrentDepth >= targetDepth;
			}
			return false;
		}

		public bool Read(ref StreamingUtf8JsonReader reader)
		{
			if (wasPeeked)
			{
				wasPeeked = false;
				return !currentToken.HasValue;
			}
			bool num = reader.Read();
			if (num)
			{
				currentToken = reader.Reader.TokenType;
				UpdateContext(ref reader);
			}
			else
			{
				currentToken = null;
			}
			wasPeeked = false;
			return num;
		}

		public bool Peek(JsonTokenType token, ref StreamingUtf8JsonReader reader)
		{
			if (wasPeeked)
			{
				if (currentToken.HasValue)
				{
					return currentToken == token;
				}
				return false;
			}
			if (Read(ref reader))
			{
				wasPeeked = true;
				return currentToken == token;
			}
			return false;
		}

		public string ReadText(ref StreamingUtf8JsonReader reader)
		{
			string empty = string.Empty;
			Utf8JsonReader reader2;
			switch (currentToken)
			{
			case JsonTokenType.Null:
				return null;
			case JsonTokenType.True:
			case JsonTokenType.False:
				reader2 = reader.Reader;
				return reader2.GetBoolean().ToString();
			case JsonTokenType.PropertyName:
			case JsonTokenType.String:
				reader2 = reader.Reader;
				return reader2.GetString();
			case JsonTokenType.Number:
			{
				Encoding uTF = Encoding.UTF8;
				reader2 = reader.Reader;
				return uTF.GetString(reader2.ValueSpan.ToArray());
			}
			default:
				throw new AmazonClientException($"Unexpected token: {currentToken}");
			}
		}

		public int Peek()
		{
			while (char.IsWhiteSpace((char)StreamPeek()))
			{
				streamReader.Read();
			}
			return StreamPeek();
		}

		private int StreamPeek()
		{
			int num = streamReader.Peek();
			if (num == -1)
			{
				streamReader.DiscardBufferedData();
				num = streamReader.Peek();
			}
			return num;
		}

		private void UpdateContext(ref StreamingUtf8JsonReader reader)
		{
			if (!currentToken.HasValue)
			{
				return;
			}
			if (currentToken.Value == JsonTokenType.StartObject || currentToken.Value == JsonTokenType.StartArray)
			{
				stack.Push(new PathSegment
				{
					SegmentType = PathSegmentType.Delimiter,
					Value = "/"
				});
			}
			else if (currentToken.Value == JsonTokenType.EndObject || currentToken.Value == JsonTokenType.EndArray)
			{
				if (stack.Peek().SegmentType == PathSegmentType.Delimiter)
				{
					stack.Pop();
					if (stack.Count > 0 && stack.Peek().SegmentType != PathSegmentType.Delimiter)
					{
						stack.Pop();
					}
				}
			}
			else if (currentToken.Value == JsonTokenType.PropertyName || (stack.Count == 0 && currentToken == JsonTokenType.String))
			{
				string value = ReadText(ref reader);
				stack.Push(new PathSegment
				{
					SegmentType = PathSegmentType.Value,
					Value = value
				});
			}
			else if (currentToken.Value != JsonTokenType.None && stack.Peek().SegmentType != PathSegmentType.Delimiter)
			{
				stack.Pop();
			}
		}

		protected override void Dispose(bool disposing)
		{
			if (!disposed)
			{
				if (disposing && streamReader != null)
				{
					streamReader.Dispose();
					streamReader = null;
				}
				disposed = true;
			}
			base.Dispose(disposing);
		}
	}
}
