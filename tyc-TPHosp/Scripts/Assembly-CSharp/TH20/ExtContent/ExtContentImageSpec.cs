using System.Collections.Generic;
using System.IO;

namespace TH20.ExtContent
{
	[DontSave]
	public class ExtContentImageSpec
	{
		public const string cKey_SourceImageFolderSpec = "SourceImageFolderSpec";

		public const string cKey_SourceImageFileName = "SourceImageFileName";

		public const string cKey_SourceImageSelectionArea = "SourceImageSelectionArea";

		public const string cKey_SourceImageRotationIndex = "SourceImageRotationIndex";

		public const int cNumRotations = 4;

		private string _folderSpec;

		private string _fileName;

		private ImageSelectionArea _selectionArea;

		private int _rotationIndex;

		public string FolderSpec
		{
			get
			{
				return _folderSpec;
			}
			set
			{
				_folderSpec = ExtContentUtils.NormalisePathSpec(value);
			}
		}

		public string FileName
		{
			get
			{
				return _fileName;
			}
			set
			{
				_fileName = value;
			}
		}

		public string FileSpec => ExtContentUtils.GetPathSpec(_folderSpec, _fileName);

		public ImageSelectionArea SelectionArea
		{
			get
			{
				return _selectionArea;
			}
			set
			{
				_selectionArea = value;
			}
		}

		public int RotationIndex
		{
			get
			{
				return _rotationIndex;
			}
			set
			{
				_rotationIndex = value;
			}
		}

		public ExtContentImageSpec()
		{
			Construct();
		}

		public ExtContentImageSpec(string folderSpec, string fileName)
		{
			Construct();
			_folderSpec = folderSpec;
			_fileName = fileName;
			OnFolderSpecChanged();
		}

		public ExtContentImageSpec(string fileSpec)
		{
			Construct();
			SetFromFileSpec(fileSpec);
			_selectionArea.Reset();
		}

		public void Reset()
		{
			_folderSpec = string.Empty;
			_fileName = string.Empty;
			_selectionArea.Reset();
			_rotationIndex = 0;
			OnFolderSpecChanged();
		}

		public void SetFromFileSpec(string fileSpec)
		{
			_folderSpec = string.Empty;
			_fileName = string.Empty;
			if (!fileSpec.IsNullOrEmpty())
			{
				_folderSpec = Path.GetDirectoryName(fileSpec);
				_fileName = Path.GetFileName(fileSpec);
			}
			OnFolderSpecChanged();
		}

		public void UpdateFrom(ExtContentImageSpec otherImageSpec)
		{
			if (otherImageSpec != null)
			{
				_folderSpec = otherImageSpec.FolderSpec;
				_fileName = otherImageSpec.FileName;
				_selectionArea.UpdateFrom(otherImageSpec.SelectionArea);
				_rotationIndex = otherImageSpec.RotationIndex;
				OnFolderSpecChanged();
			}
			else
			{
				Reset();
			}
		}

		public bool IsEqualTo(ExtContentImageSpec other)
		{
			if (other != null && FolderSpec == other.FolderSpec && FileName == other.FileName && RotationIndex == other.RotationIndex)
			{
				return SelectionArea.IsEqualTo(other.SelectionArea);
			}
			return false;
		}

		public bool AreFileSpecsEqual(ExtContentImageSpec other)
		{
			if (other != null && FolderSpec == other.FolderSpec)
			{
				return FileName == other.FileName;
			}
			return false;
		}

		public bool AreSelectionAreasEqual(ExtContentImageSpec other)
		{
			return SelectionArea.IsEqualTo(other.SelectionArea);
		}

		public bool AreRotationIndexesEqual(ExtContentImageSpec other)
		{
			return RotationIndex == other.RotationIndex;
		}

		public void IncrementRotationIndex(int incrAmt)
		{
			_rotationIndex += incrAmt;
			ValidateRotationCount(ref _rotationIndex);
		}

		public int GetRotationCountTo(int otherRotationIndex)
		{
			int retRotationCount = 0;
			if (_rotationIndex != otherRotationIndex)
			{
				retRotationCount = otherRotationIndex - _rotationIndex;
				ValidateRotationCount(ref retRotationCount);
			}
			return retRotationCount;
		}

		private void ValidateRotationCount(ref int retRotationCount)
		{
			retRotationCount %= 4;
			if (retRotationCount < 0)
			{
				retRotationCount += 4;
			}
			else if (retRotationCount >= 4)
			{
				retRotationCount -= 4;
			}
		}

		public bool ReadWriteMetaData(bool bWrite, string instanceName, Dictionary<string, string> metaData)
		{
			bool result = false;
			string text = instanceName + ".";
			if (bWrite)
			{
				if (ExtContentUtils.SetDictionaryValue(metaData, text + "SourceImageFolderSpec", _folderSpec))
				{
					result = true;
				}
				if (ExtContentUtils.SetDictionaryValue(metaData, text + "SourceImageFileName", _fileName))
				{
					result = true;
				}
				string value = _selectionArea.ToParamString();
				if (ExtContentUtils.SetDictionaryValue(metaData, text + "SourceImageSelectionArea", value))
				{
					result = true;
				}
				if (ExtContentUtils.SetDictionaryValue(metaData, text + "SourceImageRotationIndex", _rotationIndex.ToString()))
				{
					result = true;
				}
			}
			else
			{
				string retValue = string.Empty;
				ExtContentUtils.GetDictionaryValue(metaData, text + "SourceImageFolderSpec", ref _folderSpec);
				ExtContentUtils.GetDictionaryValue(metaData, text + "SourceImageFileName", ref _fileName);
				ExtContentUtils.GetDictionaryValue(metaData, text + "SourceImageSelectionArea", ref retValue);
				ExtContentUtils.GetDictionaryValue(metaData, text + "SourceImageRotationIndex", ref _rotationIndex);
				_selectionArea.FromParamString(retValue);
				OnFolderSpecChanged();
			}
			return result;
		}

		private void Construct()
		{
			_folderSpec = string.Empty;
			_fileName = string.Empty;
			_selectionArea = new ImageSelectionArea();
			_rotationIndex = 0;
		}

		private void OnFolderSpecChanged()
		{
			_folderSpec = ExtContentUtils.NormalisePathSpec(_folderSpec);
		}
	}
}
