using System;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;
using Microsoft.CSharp.RuntimeBinder;
using Namotion.Reflection;

namespace NJsonSchema.Infrastructure
{
	public static class DynamicApis
	{
		[CompilerGenerated]
		private static class _003C_003Eo__17
		{
			public static CallSite<Func<CallSite, object, bool, object>> _003C_003Ep__0;

			public static CallSite<Func<CallSite, object, string, CancellationToken, object>> _003C_003Ep__1;

			public static CallSite<Func<CallSite, object, bool, object>> _003C_003Ep__2;

			public static CallSite<Action<CallSite, object>> _003C_003Ep__3;

			public static CallSite<Func<CallSite, object, object>> _003C_003Ep__4;

			public static CallSite<Func<CallSite, object, object>> _003C_003Ep__5;

			public static CallSite<Func<CallSite, object, bool, object>> _003C_003Ep__6;

			public static CallSite<Func<CallSite, object, string>> _003C_003Ep__7;

			public static CallSite<Func<CallSite, object, IDisposable>> _003C_003Ep__8;

			public static CallSite<Func<CallSite, object, IDisposable>> _003C_003Ep__9;
		}

		[StructLayout(LayoutKind.Auto)]
		[CompilerGenerated]
		private struct _003CHttpGetAsync_003Ed__17 : IAsyncStateMachine
		{
			private static class _003C_003Eo__17
			{
				public static CallSite<Func<CallSite, object, object>> _003C_003Ep__0;

				public static CallSite<Func<CallSite, object, object>> _003C_003Ep__1;

				public static CallSite<Func<CallSite, object, bool>> _003C_003Ep__2;

				public static CallSite<Func<CallSite, object, object>> _003C_003Ep__3;

				public static CallSite<Func<CallSite, object, object>> _003C_003Ep__4;

				public static CallSite<Func<CallSite, object, object>> _003C_003Ep__5;

				public static CallSite<Func<CallSite, object, bool>> _003C_003Ep__6;

				public static CallSite<Func<CallSite, object, object>> _003C_003Ep__7;
			}

			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder<string> _003C_003Et__builder;

			public string url;

			public CancellationToken cancellationToken;

			private IDisposable _003C_003E7__wrap1;

			private IDisposable _003C_003E7__wrap2;

			private object _003C_003Eu__1;

			private Func<CallSite, object, string> _003C_003E7__wrap3;

			private CallSite<Func<CallSite, object, string>> _003C_003E7__wrap4;

			private void MoveNext()
			{
				int num = _003C_003E1__state;
				string result3;
				try
				{
					dynamic val = default(dynamic);
					if ((uint)num > 1u)
					{
						if (!SupportsHttpClientApis)
						{
							throw new NotSupportedException("The System.Net.Http.HttpClient API is not available on this platform.");
						}
						val = (IDisposable)Activator.CreateInstance(HttpClientHandlerType);
						_003C_003E7__wrap1 = val;
					}
					try
					{
						dynamic val2 = default(dynamic);
						if ((uint)num > 1u)
						{
							val2 = (IDisposable)Activator.CreateInstance(HttpClientType, val);
							_003C_003E7__wrap2 = val2;
						}
						try
						{
							dynamic val3;
							dynamic val4;
							if (num != 0)
							{
								if (num == 1)
								{
									val3 = _003C_003Eu__1;
									_003C_003Eu__1 = null;
									num = (_003C_003E1__state = -1);
									goto IL_065c;
								}
								val.UseDefaultCredentials = true;
								val4 = val2.GetAsync(url, cancellationToken).ConfigureAwait(false).GetAwaiter();
								if (!(bool)val4.IsCompleted)
								{
									num = (_003C_003E1__state = 0);
									_003C_003Eu__1 = val4;
									ICriticalNotifyCompletion awaiter = val4 as ICriticalNotifyCompletion;
									if (awaiter == null)
									{
										INotifyCompletion awaiter2 = (INotifyCompletion)(object)val4;
										_003C_003Et__builder.AwaitOnCompleted(ref awaiter2, ref this);
										awaiter2 = null;
									}
									else
									{
										_003C_003Et__builder.AwaitUnsafeOnCompleted(ref awaiter, ref this);
									}
									awaiter = null;
									return;
								}
							}
							else
							{
								val4 = _003C_003Eu__1;
								_003C_003Eu__1 = null;
								num = (_003C_003E1__state = -1);
							}
							object result = val4.GetResult();
							dynamic val5 = result;
							val5.EnsureSuccessStatusCode();
							if (DynamicApis._003C_003Eo__17._003C_003Ep__7 == null)
							{
								DynamicApis._003C_003Eo__17._003C_003Ep__7 = CallSite<Func<CallSite, object, string>>.Create(Microsoft.CSharp.RuntimeBinder.Binder.Convert(CSharpBinderFlags.None, typeof(string), typeof(DynamicApis)));
							}
							_003C_003E7__wrap3 = DynamicApis._003C_003Eo__17._003C_003Ep__7.Target;
							_003C_003E7__wrap4 = DynamicApis._003C_003Eo__17._003C_003Ep__7;
							val3 = val5.Content.ReadAsStringAsync().ConfigureAwait(false).GetAwaiter();
							if (!(bool)val3.IsCompleted)
							{
								num = (_003C_003E1__state = 1);
								_003C_003Eu__1 = val3;
								ICriticalNotifyCompletion awaiter = val3 as ICriticalNotifyCompletion;
								if (awaiter == null)
								{
									INotifyCompletion awaiter2 = (INotifyCompletion)(object)val3;
									_003C_003Et__builder.AwaitOnCompleted(ref awaiter2, ref this);
									awaiter2 = null;
								}
								else
								{
									_003C_003Et__builder.AwaitUnsafeOnCompleted(ref awaiter, ref this);
								}
								awaiter = null;
								return;
							}
							goto IL_065c;
							IL_065c:
							object result2 = val3.GetResult();
							result3 = _003C_003E7__wrap3(_003C_003E7__wrap4, result2);
						}
						finally
						{
							if (num < 0 && _003C_003E7__wrap2 != null)
							{
								_003C_003E7__wrap2.Dispose();
							}
						}
					}
					finally
					{
						if (num < 0 && _003C_003E7__wrap1 != null)
						{
							_003C_003E7__wrap1.Dispose();
						}
					}
				}
				catch (Exception exception)
				{
					_003C_003E1__state = -2;
					_003C_003Et__builder.SetException(exception);
					return;
				}
				_003C_003E1__state = -2;
				_003C_003Et__builder.SetResult(result3);
			}

			void IAsyncStateMachine.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				this.MoveNext();
			}

			[DebuggerHidden]
			private void SetStateMachine(IAsyncStateMachine stateMachine)
			{
				_003C_003Et__builder.SetStateMachine(stateMachine);
			}

			void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
			{
				//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
				this.SetStateMachine(stateMachine);
			}
		}

		private static readonly Type XPathExtensionsType;

		private static readonly Type FileType;

		private static readonly Type DirectoryType;

		private static readonly Type PathType;

		private static readonly Type HttpClientHandlerType;

		private static readonly Type HttpClientType;

		public static bool SupportsFileApis => FileType != null;

		public static bool SupportsPathApis => PathType != null;

		public static bool SupportsDirectoryApis => DirectoryType != null;

		public static bool SupportsXPathApis => XPathExtensionsType != null;

		public static bool SupportsHttpClientApis => HttpClientType != null;

		static DynamicApis()
		{
			XPathExtensionsType = TryLoadType("System.Xml.XPath.Extensions, System.Xml.XPath.XDocument", "System.Xml.XPath.Extensions, System.Xml.Linq, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089");
			HttpClientHandlerType = TryLoadType("System.Net.Http.HttpClientHandler, System.Net.Http", "System.Net.Http.HttpClientHandler, System.Net.Http, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a");
			HttpClientType = TryLoadType("System.Net.Http.HttpClient, System.Net.Http", "System.Net.Http.HttpClient, System.Net.Http, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a");
			FileType = TryLoadType("System.IO.File, System.IO.FileSystem", "System.IO.File");
			DirectoryType = TryLoadType("System.IO.Directory, System.IO.FileSystem", "System.IO.Directory");
			PathType = TryLoadType("System.IO.Path, System.IO.FileSystem", "System.IO.Path");
		}

		public unsafe static async Task<string> HttpGetAsync(string url, CancellationToken cancellationToken)
		{
			if (!SupportsHttpClientApis)
			{
				throw new NotSupportedException("The System.Net.Http.HttpClient API is not available on this platform.");
			}
			dynamic val = (IDisposable)Activator.CreateInstance(HttpClientHandlerType);
			using ((IDisposable)val)
			{
				dynamic val2 = (IDisposable)Activator.CreateInstance(HttpClientType, val);
				using ((IDisposable)val2)
				{
					val.UseDefaultCredentials = true;
					dynamic awaiter = val2.GetAsync(url, cancellationToken).ConfigureAwait(false).GetAwaiter();
					AsyncTaskMethodBuilder<string> asyncTaskMethodBuilder = default(AsyncTaskMethodBuilder<string>);
					if (!(bool)awaiter.IsCompleted)
					{
						ICriticalNotifyCompletion awaiter2 = awaiter as ICriticalNotifyCompletion;
						if (awaiter2 == null)
						{
							INotifyCompletion awaiter3 = (INotifyCompletion)(object)awaiter;
							asyncTaskMethodBuilder.AwaitOnCompleted(ref awaiter3, ref *(_003CHttpGetAsync_003Ed__17*)/*Error near IL_0309: stateMachine*/);
						}
						else
						{
							asyncTaskMethodBuilder.AwaitUnsafeOnCompleted(ref awaiter2, ref *(_003CHttpGetAsync_003Ed__17*)/*Error near IL_031c: stateMachine*/);
						}
						/*Error near IL_0325: leave MoveNext - await not detected correctly*/;
					}
					object result = awaiter.GetResult();
					dynamic val3 = result;
					val3.EnsureSuccessStatusCode();
					if (_003C_003Eo__17._003C_003Ep__7 == null)
					{
						_003C_003Eo__17._003C_003Ep__7 = CallSite<Func<CallSite, object, string>>.Create(Microsoft.CSharp.RuntimeBinder.Binder.Convert(CSharpBinderFlags.None, typeof(string), typeof(DynamicApis)));
					}
					Func<CallSite, object, string> target = _003C_003Eo__17._003C_003Ep__7.Target;
					CallSite<Func<CallSite, object, string>> _003C_003Ep__ = _003C_003Eo__17._003C_003Ep__7;
					dynamic awaiter4 = val3.Content.ReadAsStringAsync().ConfigureAwait(false).GetAwaiter();
					if (!(bool)awaiter4.IsCompleted)
					{
						ICriticalNotifyCompletion awaiter2 = awaiter4 as ICriticalNotifyCompletion;
						if (awaiter2 == null)
						{
							INotifyCompletion awaiter3 = (INotifyCompletion)(object)awaiter4;
							asyncTaskMethodBuilder.AwaitOnCompleted(ref awaiter3, ref *(_003CHttpGetAsync_003Ed__17*)/*Error near IL_0623: stateMachine*/);
						}
						else
						{
							asyncTaskMethodBuilder.AwaitUnsafeOnCompleted(ref awaiter2, ref *(_003CHttpGetAsync_003Ed__17*)/*Error near IL_0636: stateMachine*/);
						}
						/*Error near IL_063f: leave MoveNext - await not detected correctly*/;
					}
					object result2 = awaiter4.GetResult();
					return target(_003C_003Ep__, result2);
				}
			}
		}

		public static string DirectoryGetCurrentDirectory()
		{
			if (!SupportsDirectoryApis)
			{
				throw new NotSupportedException("The System.IO.Directory API is not available on this platform.");
			}
			return (string)DirectoryType.GetRuntimeMethod("GetCurrentDirectory", new Type[0]).Invoke(null, new object[0]);
		}

		public static string[] DirectoryGetDirectories(string directory)
		{
			if (!SupportsDirectoryApis)
			{
				throw new NotSupportedException("The System.IO.Directory API is not available on this platform.");
			}
			return (string[])DirectoryType.GetRuntimeMethod("GetDirectories", new Type[1] { typeof(string) }).Invoke(null, new object[1] { directory });
		}

		public static string[] DirectoryGetFiles(string directory, string filter)
		{
			if (!SupportsDirectoryApis)
			{
				throw new NotSupportedException("The System.IO.Directory API is not available on this platform.");
			}
			return (string[])DirectoryType.GetRuntimeMethod("GetFiles", new Type[2]
			{
				typeof(string),
				typeof(string)
			}).Invoke(null, new object[2] { directory, filter });
		}

		public static string DirectoryGetParent(string path)
		{
			if (!SupportsDirectoryApis)
			{
				throw new NotSupportedException("The System.IO.Directory API is not available on this platform.");
			}
			return DirectoryType.GetRuntimeMethod("GetParent", new Type[1] { typeof(string) }).Invoke(null, new object[1] { path }).TryGetPropertyValue<string>("FullName");
		}

		public static void DirectoryCreateDirectory(string directory)
		{
			if (!SupportsDirectoryApis)
			{
				throw new NotSupportedException("The System.IO.Directory API is not available on this platform.");
			}
			DirectoryType.GetRuntimeMethod("CreateDirectory", new Type[1] { typeof(string) }).Invoke(null, new object[1] { directory });
		}

		public static bool DirectoryExists(string filePath)
		{
			if (!SupportsDirectoryApis)
			{
				throw new NotSupportedException("The System.IO.Directory API is not available on this platform.");
			}
			if (string.IsNullOrEmpty(filePath))
			{
				return false;
			}
			return (bool)DirectoryType.GetRuntimeMethod("Exists", new Type[1] { typeof(string) }).Invoke(null, new object[1] { filePath });
		}

		public static bool FileExists(string filePath)
		{
			if (!SupportsFileApis)
			{
				throw new NotSupportedException("The System.IO.File API is not available on this platform.");
			}
			if (string.IsNullOrEmpty(filePath))
			{
				return false;
			}
			return (bool)FileType.GetRuntimeMethod("Exists", new Type[1] { typeof(string) }).Invoke(null, new object[1] { filePath });
		}

		public static string FileReadAllText(string filePath)
		{
			if (!SupportsFileApis)
			{
				throw new NotSupportedException("The System.IO.File API is not available on this platform.");
			}
			return (string)FileType.GetRuntimeMethod("ReadAllText", new Type[2]
			{
				typeof(string),
				typeof(Encoding)
			}).Invoke(null, new object[2]
			{
				filePath,
				Encoding.UTF8
			});
		}

		public static void FileWriteAllText(string filePath, string text)
		{
			if (!SupportsFileApis)
			{
				throw new NotSupportedException("The System.IO.File API is not available on this platform.");
			}
			FileType.GetRuntimeMethod("WriteAllText", new Type[2]
			{
				typeof(string),
				typeof(string)
			}).Invoke(null, new object[2] { filePath, text });
		}

		public static string PathCombine(string path1, string path2)
		{
			if (!SupportsPathApis)
			{
				throw new NotSupportedException("The System.IO.Path API is not available on this platform.");
			}
			return (string)PathType.GetRuntimeMethod("Combine", new Type[2]
			{
				typeof(string),
				typeof(string)
			}).Invoke(null, new object[2] { path1, path2 });
		}

		public static string PathGetFileName(string filePath)
		{
			if (!SupportsPathApis)
			{
				throw new NotSupportedException("The System.IO.Path API is not available on this platform.");
			}
			return (string)PathType.GetRuntimeMethod("GetFileName", new Type[1] { typeof(string) }).Invoke(null, new object[1] { filePath });
		}

		public static string GetFullPath(string path)
		{
			if (!SupportsPathApis)
			{
				throw new NotSupportedException("The System.IO.Path API is not available on this platform.");
			}
			return (string)PathType.GetRuntimeMethod("GetFullPath", new Type[1] { typeof(string) }).Invoke(null, new object[1] { path });
		}

		public static string PathGetDirectoryName(string filePath)
		{
			if (!SupportsPathApis)
			{
				throw new NotSupportedException("The System.IO.Path API is not available on this platform.");
			}
			return (string)PathType.GetRuntimeMethod("GetDirectoryName", new Type[1] { typeof(string) }).Invoke(null, new object[1] { filePath });
		}

		public static object XPathEvaluate(XDocument document, string path)
		{
			if (!SupportsXPathApis)
			{
				throw new NotSupportedException("The System.Xml.XPath.Extensions API is not available on this platform.");
			}
			return XPathExtensionsType.GetRuntimeMethod("XPathEvaluate", new Type[2]
			{
				typeof(XDocument),
				typeof(string)
			}).Invoke(null, new object[2] { document, path });
		}

		public static string HandleSubdirectoryRelativeReferences(string fullPath, string jsonPath)
		{
			try
			{
				if (!DirectoryExists(PathGetDirectoryName(fullPath)))
				{
					string path = PathGetFileName(fullPath);
					string text = PathGetDirectoryName(fullPath);
					string path2 = text.Replace("\\", "/").Split(new char[1] { '/' }).Last();
					if (!string.IsNullOrWhiteSpace(DirectoryGetParent(text)))
					{
						string[] array = DirectoryGetDirectories(DirectoryGetParent(text));
						foreach (string path3 in array)
						{
							string text2 = PathCombine(path3, path2);
							string text3 = PathCombine(text2, path);
							if (DirectoryExists(text2))
							{
								fullPath = PathCombine(text2, path);
								break;
							}
						}
					}
				}
				if (!FileExists(fullPath))
				{
					string text4 = PathGetDirectoryName(fullPath);
					if (DirectoryExists(text4))
					{
						string path4 = PathGetFileName(fullPath);
						string text5 = fullPath.Replace("\\", "/").Split(new char[1] { '/' })[^2];
						string[] array2 = DirectoryGetDirectories(text4);
						foreach (string path5 in array2)
						{
							string filePath = PathCombine(path5, path4);
							if (FileExists(filePath) && FileReadAllText(filePath).Contains(jsonPath.Split(new char[1] { '/' }).Last()))
							{
								fullPath = PathCombine(path5, path4);
								break;
							}
						}
					}
				}
				return fullPath;
			}
			catch
			{
				return fullPath;
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal static Task<T> FromResult<T>(T result)
		{
			return Task.FromResult(result);
		}

		private static Type TryLoadType(params string[] typeNames)
		{
			foreach (string typeName in typeNames)
			{
				try
				{
					Type type = Type.GetType(typeName, throwOnError: false);
					if (type != null)
					{
						return type;
					}
				}
				catch
				{
				}
			}
			return null;
		}
	}
}
