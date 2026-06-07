using System;
using System.Reflection;
using JWT.Algorithms;
using JWT.Serializers;

namespace JWT.Builder
{
	public sealed class JwtBuilder
	{
		private readonly JwtData _jwt;

		private IJwtEncoder _encoder;

		private IJwtDecoder _decoder;

		private IJwtValidator _validator;

		private IJsonSerializerFactory _jsonSerializerFactory;

		private IBase64UrlEncoder _urlEncoder;

		private IDateTimeProvider _dateTimeProvider;

		private ValidationParameters _valParams;

		private IJwtAlgorithm _algorithm;

		private IAlgorithmFactory _algFactory;

		private byte[][] _secrets;

		public static JwtBuilder Create()
		{
			return null;
		}

		public JwtBuilder AddHeader(HeaderName name, object value)
		{
			return null;
		}

		public JwtBuilder AddHeader(string name, object value)
		{
			return null;
		}

		public JwtBuilder AddClaim(string name, object value)
		{
			return null;
		}

		public JwtBuilder WithJsonSerializer(IJsonSerializer serializer)
		{
			return null;
		}

		public JwtBuilder WithJsonSerializer(Func<IJsonSerializer> factory)
		{
			return null;
		}

		public JwtBuilder WithJsonSerializerFactory(IJsonSerializerFactory jsonSerializerFactory)
		{
			return null;
		}

		public JwtBuilder WithDateTimeProvider(IDateTimeProvider provider)
		{
			return null;
		}

		public JwtBuilder WithEncoder(IJwtEncoder encoder)
		{
			return null;
		}

		public JwtBuilder WithDecoder(IJwtDecoder decoder)
		{
			return null;
		}

		public JwtBuilder WithValidator(IJwtValidator validator)
		{
			return null;
		}

		public JwtBuilder WithUrlEncoder(IBase64UrlEncoder urlEncoder)
		{
			return null;
		}

		public JwtBuilder WithAlgorithmFactory(IAlgorithmFactory algFactory)
		{
			return null;
		}

		public JwtBuilder WithAlgorithm(IJwtAlgorithm algorithm)
		{
			return null;
		}

		public JwtBuilder WithSecret(params string[] secrets)
		{
			return null;
		}

		public JwtBuilder WithSecret(params byte[][] secrets)
		{
			return null;
		}

		public JwtBuilder MustVerifySignature()
		{
			return null;
		}

		public JwtBuilder DoNotVerifySignature()
		{
			return null;
		}

		public JwtBuilder WithVerifySignature(bool verify)
		{
			return null;
		}

		public JwtBuilder WithValidationParameters(ValidationParameters valParams)
		{
			return null;
		}

		public JwtBuilder WithValidationParameters(Action<ValidationParameters> action)
		{
			return null;
		}

		public string Encode()
		{
			return null;
		}

		public string Encode(object payload)
		{
			return null;
		}

		public string Decode(string token)
		{
			return null;
		}

		public string DecodeHeader(string token)
		{
			return null;
		}

		public T DecodeHeader<T>(string token)
		{
			return default(T);
		}

		public object Decode(string token, Type type)
		{
			return null;
		}

		public T Decode<T>(string token)
		{
			return default(T);
		}

		private void TryCreateEncoder()
		{
		}

		private void TryCreateDecoder()
		{
		}

		private void TryCreateDecoderForHeader()
		{
		}

		private void TryCreateValidator()
		{
		}

		private void EnsureCanEncode()
		{
		}

		private void EnsureCanDecode()
		{
		}

		private void EnsureCanDecodeHeader()
		{
		}

		private bool CanEncode()
		{
			return false;
		}

		private bool CanDecode()
		{
			return false;
		}

		private bool CanDecodeHeader()
		{
			return false;
		}

		private string GetPropName(MemberInfo prop)
		{
			return null;
		}
	}
}
