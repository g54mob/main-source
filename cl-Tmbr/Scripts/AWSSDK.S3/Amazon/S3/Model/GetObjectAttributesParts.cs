using System.Collections.Generic;

namespace Amazon.S3.Model
{
	public class GetObjectAttributesParts
	{
		private bool? _isTruncated;

		private int? _maxParts;

		private int? _nextPartNumberMarker;

		private int? _partNumberMarker;

		private List<ObjectPart> _parts = (AWSConfigs.InitializeCollections ? new List<ObjectPart>() : null);

		private int? _totalPartsCount;

		public bool? IsTruncated
		{
			get
			{
				return _isTruncated;
			}
			set
			{
				_isTruncated = value;
			}
		}

		public int? MaxParts
		{
			get
			{
				return _maxParts;
			}
			set
			{
				_maxParts = value;
			}
		}

		public int? NextPartNumberMarker
		{
			get
			{
				return _nextPartNumberMarker;
			}
			set
			{
				_nextPartNumberMarker = value;
			}
		}

		public int? PartNumberMarker
		{
			get
			{
				return _partNumberMarker;
			}
			set
			{
				_partNumberMarker = value;
			}
		}

		public List<ObjectPart> Parts
		{
			get
			{
				return _parts;
			}
			set
			{
				_parts = value;
			}
		}

		public int? TotalPartsCount
		{
			get
			{
				return _totalPartsCount;
			}
			set
			{
				_totalPartsCount = value;
			}
		}

		internal bool IsSetIsTruncated()
		{
			return _isTruncated.HasValue;
		}

		internal bool IsSetMaxParts()
		{
			return _maxParts.HasValue;
		}

		internal bool IsSetNextPartNumberMarker()
		{
			return _nextPartNumberMarker.HasValue;
		}

		internal bool IsSetPartNumberMarker()
		{
			return _partNumberMarker.HasValue;
		}

		internal bool IsSetParts()
		{
			if (_parts != null)
			{
				if (_parts.Count <= 0)
				{
					return !AWSConfigs.InitializeCollections;
				}
				return true;
			}
			return false;
		}

		internal bool IsSetTotalPartsCount()
		{
			return _totalPartsCount.HasValue;
		}
	}
}
