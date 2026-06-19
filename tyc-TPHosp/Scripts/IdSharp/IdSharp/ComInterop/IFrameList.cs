using System.Runtime.InteropServices;

namespace IdSharp.ComInterop
{
	[ComVisible(true)]
	[Guid("945CF2AE-163B-4247-B286-E752EB1B709B")]
	public interface IFrameList
	{
		[DispId(805)]
		object this[int index] { get; set; }

		[DispId(806)]
		int Count { get; }

		[DispId(800)]
		object AddNew();

		[DispId(801)]
		int Add(object value);

		[DispId(802)]
		void Clear();

		[DispId(803)]
		void Remove(object value);

		[DispId(804)]
		void RemoveAt(int index);
	}
}
