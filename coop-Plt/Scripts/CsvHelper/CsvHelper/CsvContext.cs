using System;
using CsvHelper.Configuration;
using CsvHelper.TypeConversion;

namespace CsvHelper
{
	public class CsvContext
	{
		public virtual TypeConverterOptionsCache TypeConverterOptionsCache { get; set; } = new TypeConverterOptionsCache();

		public virtual TypeConverterCache TypeConverterCache { get; set; } = new TypeConverterCache();

		public virtual ClassMapCollection Maps { get; private set; }

		public IParser Parser { get; private set; }

		public IReader Reader { get; internal set; }

		public IWriter Writer { get; internal set; }

		public CsvConfiguration Configuration { get; private set; }

		public CsvContext(IReader reader)
		{
			Reader = reader;
			Parser = reader.Parser;
			Configuration = (reader.Configuration as CsvConfiguration) ?? throw new InvalidOperationException("IReader.Configuration must be of type CsvConfiguration to be used in the context.");
			Maps = new ClassMapCollection(this);
		}

		public CsvContext(IParser parser)
		{
			Parser = parser;
			Configuration = (parser.Configuration as CsvConfiguration) ?? throw new InvalidOperationException("IParser.Configuration must be of type CsvConfiguration to be used in the context.");
			Maps = new ClassMapCollection(this);
		}

		public CsvContext(IWriter writer)
		{
			Writer = writer;
			Configuration = (writer.Configuration as CsvConfiguration) ?? throw new InvalidOperationException("IWriter.Configuration must be of type CsvConfiguration to be used in the context.");
			Maps = new ClassMapCollection(this);
		}

		public CsvContext(CsvConfiguration configuration)
		{
			Configuration = configuration;
			Maps = new ClassMapCollection(this);
		}

		public virtual TMap RegisterClassMap<TMap>() where TMap : ClassMap
		{
			TMap val = ObjectResolver.Current.Resolve<TMap>(new object[0]);
			RegisterClassMap(val);
			return val;
		}

		public virtual ClassMap RegisterClassMap(Type classMapType)
		{
			if (!typeof(ClassMap).IsAssignableFrom(classMapType))
			{
				throw new ArgumentException("The class map type must inherit from CsvClassMap.");
			}
			ClassMap classMap = (ClassMap)ObjectResolver.Current.Resolve(classMapType);
			RegisterClassMap(classMap);
			return classMap;
		}

		public virtual void RegisterClassMap(ClassMap map)
		{
			if (map.MemberMaps.Count == 0 && map.ReferenceMaps.Count == 0 && map.ParameterMaps.Count == 0)
			{
				throw new ConfigurationException("No mappings were specified in the CsvClassMap.");
			}
			Maps.Add(map);
		}

		public virtual void UnregisterClassMap<TMap>() where TMap : ClassMap
		{
			UnregisterClassMap(typeof(TMap));
		}

		public virtual void UnregisterClassMap(Type classMapType)
		{
			Maps.Remove(classMapType);
		}

		public virtual void UnregisterClassMap()
		{
			Maps.Clear();
		}

		public virtual ClassMap<T> AutoMap<T>()
		{
			DefaultClassMap<T> defaultClassMap = ObjectResolver.Current.Resolve<DefaultClassMap<T>>(new object[0]);
			defaultClassMap.AutoMap(this);
			Maps.Add(defaultClassMap);
			return defaultClassMap;
		}

		public virtual ClassMap AutoMap(Type type)
		{
			Type type2 = typeof(DefaultClassMap<>).MakeGenericType(type);
			ClassMap classMap = (ClassMap)ObjectResolver.Current.Resolve(type2);
			classMap.AutoMap(this);
			Maps.Add(classMap);
			return classMap;
		}
	}
}
