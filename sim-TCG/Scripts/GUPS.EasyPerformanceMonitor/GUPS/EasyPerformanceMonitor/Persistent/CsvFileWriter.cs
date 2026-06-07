using System.Threading.Tasks;

namespace GUPS.EasyPerformanceMonitor.Persistent
{
	internal class CsvFileWriter : StringFileWriter
	{
		public CsvFileWriter(string _Path, int _FlushCount = 100)
			: base(_Path, _FlushCount)
		{
		}

		public void Append(float _Value)
		{
			Write(_Value.ToString());
		}

		public async Task AppendAsync(float _Value)
		{
			await WriteAsync(_Value.ToString());
		}

		public void Append(int _Key, float _Value)
		{
			Write($"{_Key},{_Value}");
		}

		public async Task AppendAsync(int _Key, float _Value)
		{
			await WriteAsync($"{_Key},{_Value}");
		}
	}
}
