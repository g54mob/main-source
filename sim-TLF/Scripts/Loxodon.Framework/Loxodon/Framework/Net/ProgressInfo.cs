using System;

namespace Loxodon.Framework.Net
{
	public class ProgressInfo
	{
		private long totalSize;

		private long completedSize;

		private int totalCount;

		private int completedCount;

		private float speed;

		private long lastTime = -1L;

		private long lastValue = -1L;

		private long lastTime2 = -1L;

		private long lastValue2 = -1L;

		public long TotalSize
		{
			get
			{
				return totalSize;
			}
			set
			{
				totalSize = value;
			}
		}

		public long CompletedSize
		{
			get
			{
				return completedSize;
			}
			set
			{
				completedSize = value;
				OnUpdate();
			}
		}

		public int TotalCount
		{
			get
			{
				return totalCount;
			}
			set
			{
				totalCount = value;
			}
		}

		public int CompletedCount
		{
			get
			{
				return completedCount;
			}
			set
			{
				completedCount = value;
			}
		}

		public virtual float Value
		{
			get
			{
				if (totalSize <= 0)
				{
					return 0f;
				}
				return (float)completedSize / (float)totalSize;
			}
		}

		public ProgressInfo()
			: this(0L, 0L)
		{
		}

		public ProgressInfo(long totalSize, long completedSize)
		{
			this.totalSize = totalSize;
			this.completedSize = completedSize;
			lastTime = DateTime.UtcNow.Ticks / 10000;
			lastValue = this.completedSize;
			lastTime2 = lastTime;
			lastValue2 = lastValue;
		}

		private void OnUpdate()
		{
			long num = DateTime.UtcNow.Ticks / 10000;
			if (num - lastTime >= 1000)
			{
				lastTime2 = lastTime;
				lastValue2 = lastValue;
				lastTime = num;
				lastValue = completedSize;
			}
			float num2 = (float)(num - lastTime2) / 1000f;
			speed = (float)(completedSize - lastValue2) / num2;
		}

		public virtual float GetTotalSize(UNIT unit = UNIT.BYTE)
		{
			return unit switch
			{
				UNIT.KB => (float)totalSize / 1024f, 
				UNIT.MB => (float)totalSize / 1048576f, 
				UNIT.GB => (float)totalSize / 1.0737418E+09f, 
				_ => totalSize, 
			};
		}

		public virtual float GetCompletedSize(UNIT unit = UNIT.BYTE)
		{
			return unit switch
			{
				UNIT.KB => (float)completedSize / 1024f, 
				UNIT.MB => (float)completedSize / 1048576f, 
				UNIT.GB => (float)completedSize / 1.0737418E+09f, 
				_ => completedSize, 
			};
		}

		public virtual float GetSpeed(UNIT unit = UNIT.BYTE)
		{
			return unit switch
			{
				UNIT.KB => speed / 1024f, 
				UNIT.MB => speed / 1048576f, 
				UNIT.GB => speed / 1.0737418E+09f, 
				_ => speed, 
			};
		}
	}
}
