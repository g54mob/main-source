using System;

namespace Noesis
{
	public interface IDataObject
	{
		object GetData(Type format);

		bool GetDataPresent(Type format);

		void SetData(Type format, object data);
	}
}
