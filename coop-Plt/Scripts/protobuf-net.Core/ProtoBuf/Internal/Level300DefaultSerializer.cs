using System;
using ProtoBuf.Serializers;

namespace ProtoBuf.Internal
{
	internal class Level300DefaultSerializer : Level240DefaultSerializer, ISerializer<decimal>, ISerializer<decimal?>, IValueChecker<decimal>, ISerializer<Guid>, ISerializer<Guid?>, IValueChecker<Guid>
	{
		SerializerFeatures ISerializer<Guid>.Features => SerializerFeatures.WireTypeString | SerializerFeatures.CategoryScalar;

		SerializerFeatures ISerializer<Guid?>.Features => SerializerFeatures.WireTypeString | SerializerFeatures.CategoryScalar;

		SerializerFeatures ISerializer<decimal>.Features => SerializerFeatures.WireTypeString | SerializerFeatures.CategoryScalar;

		SerializerFeatures ISerializer<decimal?>.Features => SerializerFeatures.WireTypeString | SerializerFeatures.CategoryScalar;

		bool IValueChecker<decimal>.HasNonTrivialValue(decimal value)
		{
			return !value.Equals(0m);
		}

		bool IValueChecker<decimal>.IsNull(decimal value)
		{
			return false;
		}

		bool IValueChecker<Guid>.HasNonTrivialValue(Guid value)
		{
			return !value.Equals(Guid.Empty);
		}

		bool IValueChecker<Guid>.IsNull(Guid value)
		{
			return false;
		}

		Guid ISerializer<Guid>.Read(ref ProtoReader.State state, Guid value)
		{
			return GuidHelper.Read(ref state);
		}

		void ISerializer<Guid>.Write(ref ProtoWriter.State state, Guid value)
		{
			GuidHelper.Write(ref state, in value, asBytes: false);
		}

		decimal ISerializer<decimal>.Read(ref ProtoReader.State state, decimal value)
		{
			return BclHelpers.ReadDecimalString(ref state);
		}

		void ISerializer<decimal>.Write(ref ProtoWriter.State state, decimal value)
		{
			BclHelpers.WriteDecimalString(ref state, value);
		}

		decimal? ISerializer<decimal?>.Read(ref ProtoReader.State state, decimal? value)
		{
			return ((ISerializer<decimal>)this).Read(ref state, value.GetValueOrDefault());
		}

		void ISerializer<decimal?>.Write(ref ProtoWriter.State state, decimal? value)
		{
			((ISerializer<decimal>)this).Write(ref state, value.Value);
		}

		Guid? ISerializer<Guid?>.Read(ref ProtoReader.State state, Guid? value)
		{
			return ((ISerializer<Guid>)this).Read(ref state, value.GetValueOrDefault());
		}

		void ISerializer<Guid?>.Write(ref ProtoWriter.State state, Guid? value)
		{
			((ISerializer<Guid>)this).Write(ref state, value.Value);
		}
	}
}
