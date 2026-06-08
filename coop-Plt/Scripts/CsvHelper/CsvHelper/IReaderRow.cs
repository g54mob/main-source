using System;
using CsvHelper.Configuration;
using CsvHelper.TypeConversion;

namespace CsvHelper
{
	public interface IReaderRow
	{
		int ColumnCount { get; }

		int CurrentIndex { get; }

		string[] HeaderRecord { get; }

		IParser Parser { get; }

		CsvContext Context { get; }

		IReaderConfiguration Configuration { get; }

		string this[int index] { get; }

		string this[string name] { get; }

		string this[string name, int index] { get; }

		string GetField(int index);

		string GetField(string name);

		string GetField(string name, int index);

		object GetField(Type type, int index);

		object GetField(Type type, string name);

		object GetField(Type type, string name, int index);

		object GetField(Type type, int index, ITypeConverter converter);

		object GetField(Type type, string name, ITypeConverter converter);

		object GetField(Type type, string name, int index, ITypeConverter converter);

		T GetField<T>(int index);

		T GetField<T>(string name);

		T GetField<T>(string name, int index);

		T GetField<T>(int index, ITypeConverter converter);

		T GetField<T>(string name, ITypeConverter converter);

		T GetField<T>(string name, int index, ITypeConverter converter);

		T GetField<T, TConverter>(int index) where TConverter : ITypeConverter;

		T GetField<T, TConverter>(string name) where TConverter : ITypeConverter;

		T GetField<T, TConverter>(string name, int index) where TConverter : ITypeConverter;

		bool TryGetField(Type type, int index, out object field);

		bool TryGetField(Type type, string name, out object field);

		bool TryGetField(Type type, string name, int index, out object field);

		bool TryGetField(Type type, int index, ITypeConverter converter, out object field);

		bool TryGetField(Type type, string name, ITypeConverter converter, out object field);

		bool TryGetField(Type type, string name, int index, ITypeConverter converter, out object field);

		bool TryGetField<T>(int index, out T field);

		bool TryGetField<T>(string name, out T field);

		bool TryGetField<T>(string name, int index, out T field);

		bool TryGetField<T>(int index, ITypeConverter converter, out T field);

		bool TryGetField<T>(string name, ITypeConverter converter, out T field);

		bool TryGetField<T>(string name, int index, ITypeConverter converter, out T field);

		bool TryGetField<T, TConverter>(int index, out T field) where TConverter : ITypeConverter;

		bool TryGetField<T, TConverter>(string name, out T field) where TConverter : ITypeConverter;

		bool TryGetField<T, TConverter>(string name, int index, out T field) where TConverter : ITypeConverter;

		T GetRecord<T>();

		T GetRecord<T>(T anonymousTypeDefinition);

		object GetRecord(Type type);
	}
}
