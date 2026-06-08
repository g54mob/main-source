using System;

namespace Amazon.S3.Model
{
	public class PartETag : IComparable<PartETag>
	{
		private string _checksumCRC32;

		private string _checksumCRC32C;

		private string _checksumCRC64NVME;

		private string _checksumSHA1;

		private string _checksumSHA256;

		private int? partNumber;

		private string eTag;

		public int? PartNumber
		{
			get
			{
				return partNumber;
			}
			set
			{
				partNumber = value;
			}
		}

		public string ETag
		{
			get
			{
				return eTag;
			}
			set
			{
				eTag = value;
			}
		}

		public string ChecksumCRC32
		{
			get
			{
				return _checksumCRC32;
			}
			set
			{
				_checksumCRC32 = value;
			}
		}

		public string ChecksumCRC32C
		{
			get
			{
				return _checksumCRC32C;
			}
			set
			{
				_checksumCRC32C = value;
			}
		}

		public string ChecksumCRC64NVME
		{
			get
			{
				return _checksumCRC64NVME;
			}
			set
			{
				_checksumCRC64NVME = value;
			}
		}

		public string ChecksumSHA1
		{
			get
			{
				return _checksumSHA1;
			}
			set
			{
				_checksumSHA1 = value;
			}
		}

		public string ChecksumSHA256
		{
			get
			{
				return _checksumSHA256;
			}
			set
			{
				_checksumSHA256 = value;
			}
		}

		public PartETag()
		{
		}

		public PartETag(int partNumber, string eTag)
		{
			this.partNumber = partNumber;
			this.eTag = eTag;
		}

		public PartETag(UploadPartResponse uploadPartResponse)
			: this(uploadPartResponse, copyChecksums: false)
		{
		}

		public PartETag(UploadPartResponse uploadPartResponse, bool copyChecksums)
		{
			partNumber = uploadPartResponse.PartNumber;
			eTag = uploadPartResponse.ETag;
			if (copyChecksums)
			{
				ChecksumCRC32C = uploadPartResponse.ChecksumCRC32C;
				ChecksumCRC32 = uploadPartResponse.ChecksumCRC32;
				ChecksumCRC64NVME = uploadPartResponse.ChecksumCRC64NVME;
				ChecksumSHA1 = uploadPartResponse.ChecksumSHA1;
				ChecksumSHA256 = uploadPartResponse.ChecksumSHA256;
			}
		}

		public PartETag(CopyPartResponse copyPartResponse)
			: this(copyPartResponse, copyChecksums: false)
		{
		}

		public PartETag(CopyPartResponse copyPartResponse, bool copyChecksums)
		{
			partNumber = copyPartResponse.PartNumber;
			eTag = copyPartResponse.ETag;
			if (copyChecksums)
			{
				ChecksumCRC32C = copyPartResponse.ChecksumCRC32C;
				ChecksumCRC32 = copyPartResponse.ChecksumCRC32;
				ChecksumCRC64NVME = copyPartResponse.ChecksumCRC64NVME;
				ChecksumSHA1 = copyPartResponse.ChecksumSHA1;
				ChecksumSHA256 = copyPartResponse.ChecksumSHA256;
			}
		}

		public int CompareTo(PartETag other)
		{
			return PartNumber.GetValueOrDefault().CompareTo(other.PartNumber.GetValueOrDefault());
		}

		internal bool IsSetPartNumber()
		{
			return partNumber.HasValue;
		}

		internal bool IsSetETag()
		{
			return eTag != null;
		}

		internal bool IsSetChecksumCRC32()
		{
			return _checksumCRC32 != null;
		}

		internal bool IsSetChecksumCRC32C()
		{
			return _checksumCRC32C != null;
		}

		internal bool IsSetChecksumCRC64NVME()
		{
			return _checksumCRC64NVME != null;
		}

		internal bool IsSetChecksumSHA1()
		{
			return _checksumSHA1 != null;
		}

		internal bool IsSetChecksumSHA256()
		{
			return _checksumSHA256 != null;
		}
	}
}
