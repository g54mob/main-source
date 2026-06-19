using System;
using System.IO;
using Microsoft.CodeAnalysis;
using RoslynCSharp.Compiler;
using UnityEngine;

namespace RoslynCSharp
{
	[CreateAssetMenu(fileName = "Assembly Reference Asset", menuName = "Roslyn C#/Assembly Reference Asset")]
	public class AssemblyReferenceAsset : ScriptableObject, IMetadataReferenceProvider, ISerializationCallbackReceiver
	{
		[SerializeField]
		[HideInInspector]
		private string assemblyName = "";

		[SerializeField]
		[HideInInspector]
		private string assemblyPath = "";

		[SerializeField]
		[HideInInspector]
		private byte[] assemblyImage;

		[SerializeField]
		[HideInInspector]
		private long lastWriteTimeTicks;

		private DateTime lastWriteTime = DateTime.Now;

		public MetadataReference CompilerReference => GetReferences();

		public string AssemblyName => assemblyName;

		public string AssemblyPath => assemblyPath;

		public byte[] AssemblyImage => assemblyImage;

		public DateTime LastWriteTime => lastWriteTime;

		public bool IsValid
		{
			get
			{
				if (assemblyImage != null)
				{
					return assemblyImage.Length != 0;
				}
				return false;
			}
		}

		public void UpdateAssemblyReference(string referencePath, string assemblyName)
		{
			if (referencePath == null)
			{
				throw new ArgumentNullException("referencePath");
			}
			if (referencePath == string.Empty)
			{
				throw new ArgumentException("Path cannot be empty");
			}
			if (assemblyName == null)
			{
				throw new ArgumentNullException("assemblyName");
			}
			this.assemblyName = "";
			assemblyPath = "";
			assemblyImage = new byte[0];
			if (File.Exists(referencePath))
			{
				this.assemblyName = assemblyName;
				assemblyPath = referencePath;
				assemblyImage = File.ReadAllBytes(referencePath);
				lastWriteTime = File.GetLastWriteTime(referencePath);
			}
		}

		public override string ToString()
		{
			string text = assemblyName;
			if (string.IsNullOrEmpty(text))
			{
				text = "<Invalid Assembly>";
			}
			return string.Format("{0}({1})", "AssemblyReferenceAsset", text);
		}

		void ISerializationCallbackReceiver.OnBeforeSerialize()
		{
			lastWriteTimeTicks = lastWriteTime.Ticks;
		}

		void ISerializationCallbackReceiver.OnAfterDeserialize()
		{
			lastWriteTime = new DateTime(lastWriteTimeTicks);
			if (File.Exists(assemblyPath) && File.GetLastWriteTime(assemblyPath) > lastWriteTime)
			{
				UpdateAssemblyReference(assemblyPath, assemblyName);
			}
		}

		private MetadataReference GetReferences()
		{
			if (!File.Exists(assemblyPath))
			{
				if (assemblyImage != null && assemblyImage.Length != 0)
				{
					return AssemblyReference.FromImage(assemblyImage).CompilerReference;
				}
				throw new Exception("Assembly reference asset is invalid!");
			}
			return AssemblyReference.FromNameOrFile(assemblyPath).CompilerReference;
		}
	}
}
