#define TRACE
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using IdSharp.ComInterop;
using IdSharp.Tagging.ID3v2.Frames;
using IdSharp.Tagging.ID3v2.Frames.Lists;
using IdSharp.Utils;

namespace IdSharp.Tagging.ID3v2
{
	internal class FrameContainer : IFrameContainer, INotifyPropertyChanged, INotifyInvalidData
	{
		private FrameBinder m_FrameBinder;

		private List<UnknownFrame> m_UnknownFrames;

		private Dictionary<string, IFrame> m_ID3v24SingleOccurrenceFrames;

		private Dictionary<string, IBindingList> m_ID3v24MultipleOccurrenceFrames;

		private Dictionary<string, IFrame> m_ID3v23SingleOccurrenceFrames;

		private Dictionary<string, IBindingList> m_ID3v23MultipleOccurrenceFrames;

		private Dictionary<string, IFrame> m_ID3v22SingleOccurrenceFrames;

		private Dictionary<string, IBindingList> m_ID3v22MultipleOccurrenceFrames;

		private Dictionary<string, string> m_ID3v24FrameAliases;

		private Dictionary<string, string> m_ID3v23FrameAliases;

		private AttachedPictureBindingList m_AttachedPictureList;

		private UserDefinedUrlBindingList m_UserDefinedUrlList;

		private CommentsBindingList m_CommentsList;

		private UrlBindingList m_ArtistUrlList;

		private UrlBindingList m_CommercialInfoUrlList;

		private UserDefinedTextBindingList m_UserDefinedTextList;

		private RelativeVolumeAdjustmentBindingList m_RelativeVolumeAdjustmentList;

		private UnsynchronizedLyricsBindingList m_UnsynchronizedLyricsList;

		private GeneralEncapsulatedObjectBindingList m_GeneralEncapsulatedObjectList;

		private UniqueFileIdentifierBindingList m_UniqueFileIdentifierList;

		private PrivateFrameBindingList m_PrivateFrameList;

		private PopularimeterBindingList m_PopularimeterList;

		private TermsOfUseBindingList m_TermsOfUseList;

		private LinkedInformationBindingList m_LinkedInformationList;

		private CommercialBindingList m_CommercialInfoList;

		private EncryptionMethodBindingList m_EncryptionMethodList;

		private GroupIdentificationBindingList m_GroupIdentificationList;

		private SignatureBindingList m_SignatureList;

		private AudioEncryptionBindingList m_AudioEncryptionList;

		private EncryptedMetaFrameBindingList m_EncryptedMetaFrameList;

		private SynchronizedTextBindingList m_SynchronizedLyricsList;

		private EqualizationListBindingList m_EqualizationList;

		private AudioTextBindingList m_AudioTextList;

		private TextFrame m_Genre;

		private LanguageFrame m_Languages;

		private MusicCDIdentifier m_MusicCDIdentifier;

		private InvolvedPersonList m_InvolvedPersonList;

		private RecommendedBufferSize m_RecommendedBufferSize;

		private Ownership m_Ownership;

		private PositionSynchronization m_PositionSynchronization;

		private SeekNextTag m_SeekNextTag;

		private MusicianCreditsList m_MusicianCreditsList;

		private EventTiming m_EventTiming;

		private MpegLookupTable m_MpegLookupTable;

		private Reverb m_Reverb;

		private SynchronizedTempoCodes m_SynchronizedTempoCodes;

		private AudioSeekPointIndex m_AudioSeekPointIndex;

		private PlayCount m_PlayCount;

		private IUrlFrame m_AudioFileUrl;

		private IUrlFrame m_AudioSourceUrl;

		private IUrlFrame m_InternetRadioStationUrl;

		private IUrlFrame m_PaymentUrl;

		private IUrlFrame m_CopyrightUrl;

		private IUrlFrame m_PublisherUrl;

		private TextFrame m_Title;

		private TextFrame m_Album;

		private TextFrame m_EncodedByWho;

		private TextFrame m_Artist;

		private TextFrame m_Year;

		private TextFrame m_Composer;

		private TextFrame m_OriginalArtist;

		private TextFrame m_Copyright;

		private TextFrame m_RemixedBy;

		private TextFrame m_Publisher;

		private TextFrame m_InternetRadioStationName;

		private TextFrame m_InternetRadioStationOwner;

		private TextFrame m_Accompaniment;

		private TextFrame m_Conductor;

		private TextFrame m_Lyricist;

		private TextFrame m_OriginalLyricist;

		private TextFrame m_TrackNumber;

		private TextFrame m_BPM;

		private TextFrame m_FileType;

		private TextFrame m_DiscNumber;

		private TextFrame m_ISRC;

		private TextFrame m_EncoderSettings;

		private TextFrame m_IsPartOfCompilation;

		private TextFrame m_ReleaseTimestamp;

		private TextFrame m_OriginalReleaseTimestamp;

		private TextFrame m_RecordingTimestamp;

		private TextFrame m_DateRecorded;

		private TextFrame m_TimeRecorded;

		private TextFrame m_PlaylistDelayMilliseconds;

		private TextFrame m_InitialKey;

		private TextFrame m_EncodingTimestamp;

		private TextFrame m_TaggingTimestamp;

		private TextFrame m_ContentGroup;

		private TextFrame m_Mood;

		private TextFrame m_LengthMilliseconds;

		private TextFrame m_MediaType;

		private TextFrame m_FileSizeExcludingTag;

		private TextFrame m_OriginalReleaseYear;

		private TextFrame m_OriginalSourceTitle;

		private TextFrame m_OriginalFileName;

		private TextFrame m_FileOwnerName;

		private TextFrame m_RecordingDates;

		private TextFrame m_Subtitle;

		private TextFrame m_AlbumSortOrder;

		private TextFrame m_ArtistSortOrder;

		private TextFrame m_TitleSortOrder;

		private TextFrame m_ProducedNotice;

		private TextFrame m_SetSubtitle;

		public BindingList<IUniqueFileIdentifier> UniqueFileIdentifierList => m_UniqueFileIdentifierList;

		public string Album
		{
			get
			{
				return m_Album.Value;
			}
			set
			{
				m_Album.Value = value;
			}
		}

		public string BPM
		{
			get
			{
				return m_BPM.Value;
			}
			set
			{
				m_BPM.Value = value;
			}
		}

		public string Composer
		{
			get
			{
				return m_Composer.Value;
			}
			set
			{
				m_Composer.Value = value;
			}
		}

		public string Genre
		{
			get
			{
				return m_Genre.Value;
			}
			set
			{
				m_Genre.Value = value;
			}
		}

		public string Copyright
		{
			get
			{
				return m_Copyright.Value;
			}
			set
			{
				m_Copyright.Value = value;
			}
		}

		public string DateRecorded
		{
			get
			{
				return m_DateRecorded.Value;
			}
			set
			{
				m_DateRecorded.Value = value;
			}
		}

		public int? PlaylistDelayMilliseconds
		{
			get
			{
				if (int.TryParse(m_PlaylistDelayMilliseconds.Value, out var result))
				{
					return result;
				}
				return null;
			}
			set
			{
				if (!value.HasValue)
				{
					m_PlaylistDelayMilliseconds.Value = null;
					return;
				}
				if (value < 0)
				{
					throw new ArgumentOutOfRangeException("Value cannot be less than 0");
				}
				m_PlaylistDelayMilliseconds.Value = value.Value.ToString();
			}
		}

		public string EncodedByWho
		{
			get
			{
				return m_EncodedByWho.Value;
			}
			set
			{
				m_EncodedByWho.Value = value;
			}
		}

		public string Lyricist
		{
			get
			{
				return m_Lyricist.Value;
			}
			set
			{
				m_Lyricist.Value = value;
			}
		}

		public string FileType
		{
			get
			{
				return m_FileType.Value;
			}
			set
			{
				m_FileType.Value = value;
			}
		}

		public string TimeRecorded
		{
			get
			{
				return m_TimeRecorded.Value;
			}
			set
			{
				m_TimeRecorded.Value = value;
			}
		}

		public string ContentGroup
		{
			get
			{
				return m_ContentGroup.Value;
			}
			set
			{
				m_ContentGroup.Value = value;
			}
		}

		public string Title
		{
			get
			{
				return m_Title.Value;
			}
			set
			{
				m_Title.Value = value;
			}
		}

		public string Artist
		{
			get
			{
				return m_Artist.Value;
			}
			set
			{
				m_Artist.Value = value;
			}
		}

		public string Subtitle
		{
			get
			{
				return m_Subtitle.Value;
			}
			set
			{
				m_Subtitle.Value = value;
			}
		}

		public string InitialKey
		{
			get
			{
				return m_InitialKey.Value;
			}
			set
			{
				m_InitialKey.Value = value;
			}
		}

		public ILanguageFrame Languages => m_Languages;

		public int? LengthMilliseconds
		{
			get
			{
				if (int.TryParse(m_LengthMilliseconds.Value, out var result))
				{
					return result;
				}
				return null;
			}
			set
			{
				if (!value.HasValue)
				{
					m_LengthMilliseconds.Value = null;
					return;
				}
				if (value < 0)
				{
					throw new ArgumentOutOfRangeException("Value cannot be less than 0");
				}
				m_LengthMilliseconds.Value = value.Value.ToString();
			}
		}

		public string MediaType
		{
			get
			{
				return m_MediaType.Value;
			}
			set
			{
				m_MediaType.Value = value;
			}
		}

		public string OriginalSourceTitle
		{
			get
			{
				return m_OriginalSourceTitle.Value;
			}
			set
			{
				m_OriginalSourceTitle.Value = value;
			}
		}

		public string OriginalFileName
		{
			get
			{
				return m_OriginalFileName.Value;
			}
			set
			{
				m_OriginalFileName.Value = value;
			}
		}

		public string OriginalLyricist
		{
			get
			{
				return m_OriginalLyricist.Value;
			}
			set
			{
				m_OriginalLyricist.Value = value;
			}
		}

		public string OriginalArtist
		{
			get
			{
				return m_OriginalArtist.Value;
			}
			set
			{
				m_OriginalArtist.Value = value;
			}
		}

		public string OriginalReleaseYear
		{
			get
			{
				return m_OriginalReleaseYear.Value;
			}
			set
			{
				m_OriginalReleaseYear.Value = value;
			}
		}

		public string FileOwnerName
		{
			get
			{
				return m_FileOwnerName.Value;
			}
			set
			{
				m_FileOwnerName.Value = value;
			}
		}

		public string Accompaniment
		{
			get
			{
				return m_Accompaniment.Value;
			}
			set
			{
				m_Accompaniment.Value = value;
			}
		}

		public string Conductor
		{
			get
			{
				return m_Conductor.Value;
			}
			set
			{
				m_Conductor.Value = value;
			}
		}

		public string RemixedBy
		{
			get
			{
				return m_RemixedBy.Value;
			}
			set
			{
				m_RemixedBy.Value = value;
			}
		}

		public string DiscNumber
		{
			get
			{
				return m_DiscNumber.Value;
			}
			set
			{
				m_DiscNumber.Value = value;
			}
		}

		public string Publisher
		{
			get
			{
				return m_Publisher.Value;
			}
			set
			{
				m_Publisher.Value = value;
			}
		}

		public string TrackNumber
		{
			get
			{
				return m_TrackNumber.Value;
			}
			set
			{
				m_TrackNumber.Value = value;
			}
		}

		public string RecordingDates
		{
			get
			{
				return m_RecordingDates.Value;
			}
			set
			{
				m_RecordingDates.Value = value;
			}
		}

		public string InternetRadioStationName
		{
			get
			{
				return m_InternetRadioStationName.Value;
			}
			set
			{
				m_InternetRadioStationName.Value = value;
			}
		}

		public string InternetRadioStationOwner
		{
			get
			{
				return m_InternetRadioStationOwner.Value;
			}
			set
			{
				m_InternetRadioStationOwner.Value = value;
			}
		}

		public long? FileSizeExcludingTag
		{
			get
			{
				if (long.TryParse(m_FileSizeExcludingTag.Value, out var result))
				{
					return result;
				}
				return null;
			}
			set
			{
				if (!value.HasValue)
				{
					m_FileSizeExcludingTag.Value = null;
					return;
				}
				if (value < 0)
				{
					throw new ArgumentOutOfRangeException("Value cannot be less than 0");
				}
				m_FileSizeExcludingTag.Value = value.Value.ToString();
			}
		}

		public string ISRC
		{
			get
			{
				return m_ISRC.Value;
			}
			set
			{
				m_ISRC.Value = value;
			}
		}

		public string EncoderSettings
		{
			get
			{
				return m_EncoderSettings.Value;
			}
			set
			{
				m_EncoderSettings.Value = value;
			}
		}

		public string Year
		{
			get
			{
				return m_Year.Value;
			}
			set
			{
				m_Year.Value = value;
			}
		}

		public BindingList<ITXXXFrame> UserDefinedText => m_UserDefinedTextList;

		public BindingList<IUrlFrame> CommercialInfoUrlList => m_CommercialInfoUrlList;

		public string CopyrightUrl
		{
			get
			{
				return m_CopyrightUrl.Value;
			}
			set
			{
				m_CopyrightUrl.Value = value;
			}
		}

		public string AudioFileUrl
		{
			get
			{
				return m_AudioFileUrl.Value;
			}
			set
			{
				m_AudioFileUrl.Value = value;
			}
		}

		public BindingList<IUrlFrame> ArtistUrlList => m_ArtistUrlList;

		public string AudioSourceUrl
		{
			get
			{
				return m_AudioSourceUrl.Value;
			}
			set
			{
				m_AudioSourceUrl.Value = value;
			}
		}

		public string InternetRadioStationUrl
		{
			get
			{
				return m_InternetRadioStationUrl.Value;
			}
			set
			{
				m_InternetRadioStationUrl.Value = value;
			}
		}

		public string PaymentUrl
		{
			get
			{
				return m_PaymentUrl.Value;
			}
			set
			{
				m_PaymentUrl.Value = value;
			}
		}

		public string PublisherUrl
		{
			get
			{
				return m_PublisherUrl.Value;
			}
			set
			{
				m_PublisherUrl.Value = value;
			}
		}

		public BindingList<IWXXXFrame> UserDefinedUrlList => m_UserDefinedUrlList;

		public IInvolvedPersonList InvolvedPersonList => m_InvolvedPersonList;

		public IMusicCDIdentifier MusicCDIdentifier => m_MusicCDIdentifier;

		public IEventTiming EventTiming => m_EventTiming;

		public IMpegLookupTable MpegLookupTable => m_MpegLookupTable;

		public ISynchronizedTempoCodes SynchronizedTempoCodeList => m_SynchronizedTempoCodes;

		public BindingList<IUnsynchronizedText> UnsynchronizedLyricsList => m_UnsynchronizedLyricsList;

		public BindingList<ISynchronizedText> SynchronizedLyrics => m_SynchronizedLyricsList;

		public BindingList<IComments> CommentsList => m_CommentsList;

		public BindingList<IRelativeVolumeAdjustment> RelativeVolumeAdjustmentList => m_RelativeVolumeAdjustmentList;

		public BindingList<IEqualizationList> EqualizationList => m_EqualizationList;

		public IReverb Reverb => m_Reverb;

		public BindingList<IAttachedPicture> PictureList => m_AttachedPictureList;

		public BindingList<IGeneralEncapsulatedObject> GeneralEncapsulatedObjectList => m_GeneralEncapsulatedObjectList;

		public IPlayCount PlayCount => m_PlayCount;

		public BindingList<IPopularimeter> PopularimeterList => m_PopularimeterList;

		public IRecommendedBufferSize RecommendedBufferSize => m_RecommendedBufferSize;

		public BindingList<IAudioEncryption> AudioEncryptionList => m_AudioEncryptionList;

		public BindingList<ILinkedInformation> LinkedInformationList => m_LinkedInformationList;

		public IPositionSynchronization PositionSynchronization => m_PositionSynchronization;

		public IAudioSeekPointIndex AudioSeekPointIndex => m_AudioSeekPointIndex;

		public BindingList<ITermsOfUse> TermsOfUseList => m_TermsOfUseList;

		public BindingList<ICommercial> CommercialInfoList => m_CommercialInfoList;

		public BindingList<IEncryptionMethod> EncryptionMethodList => m_EncryptionMethodList;

		public BindingList<IGroupIdentification> GroupIdentificationList => m_GroupIdentificationList;

		public BindingList<IPrivateFrame> PrivateFrameList => m_PrivateFrameList;

		public bool IsPartOfCompilation
		{
			get
			{
				if (int.TryParse(m_IsPartOfCompilation.Value, out var result) && result == 1)
				{
					return true;
				}
				return false;
			}
			set
			{
				m_IsPartOfCompilation.Value = (value ? "1" : "");
			}
		}

		public string ReleaseTimestamp
		{
			get
			{
				return m_ReleaseTimestamp.Value;
			}
			set
			{
				m_ReleaseTimestamp.Value = value;
			}
		}

		public string OriginalReleaseTimestamp
		{
			get
			{
				return m_OriginalReleaseTimestamp.Value;
			}
			set
			{
				m_OriginalReleaseTimestamp.Value = value;
			}
		}

		public string RecordingTimestamp
		{
			get
			{
				return m_RecordingTimestamp.Value;
			}
			set
			{
				m_RecordingTimestamp.Value = value;
			}
		}

		public string EncodingTimestamp
		{
			get
			{
				return m_EncodingTimestamp.Value;
			}
			set
			{
				m_EncodingTimestamp.Value = value;
			}
		}

		public string TaggingTimestamp
		{
			get
			{
				return m_TaggingTimestamp.Value;
			}
			set
			{
				m_TaggingTimestamp.Value = value;
			}
		}

		public string Mood
		{
			get
			{
				return m_Mood.Value;
			}
			set
			{
				m_Mood.Value = value;
			}
		}

		public string AlbumSortOrder
		{
			get
			{
				return m_AlbumSortOrder.Value;
			}
			set
			{
				m_AlbumSortOrder.Value = value;
			}
		}

		public string ArtistSortOrder
		{
			get
			{
				return m_ArtistSortOrder.Value;
			}
			set
			{
				m_ArtistSortOrder.Value = value;
			}
		}

		public string TitleSortOrder
		{
			get
			{
				return m_TitleSortOrder.Value;
			}
			set
			{
				m_TitleSortOrder.Value = value;
			}
		}

		public string ProducedNotice
		{
			get
			{
				return m_ProducedNotice.Value;
			}
			set
			{
				m_ProducedNotice.Value = value;
			}
		}

		public string SetSubtitle
		{
			get
			{
				return m_SetSubtitle.Value;
			}
			set
			{
				m_SetSubtitle.Value = value;
			}
		}

		public IOwnership Ownership => m_Ownership;

		public ISeekNextTag SeekNextTag => m_SeekNextTag;

		public BindingList<ISignature> SignatureList => m_SignatureList;

		public IMusicianCreditsList MusicianCreditsList => m_MusicianCreditsList;

		public BindingList<IAudioText> AudioTextList => m_AudioTextList;

		public event PropertyChangedEventHandler PropertyChanged;

		public event InvalidDataEventHandler InvalidData;

		public FrameContainer()
		{
			m_FrameBinder = new FrameBinder(this);
			m_UnknownFrames = new List<UnknownFrame>();
			m_ID3v24SingleOccurrenceFrames = new Dictionary<string, IFrame>();
			m_ID3v24MultipleOccurrenceFrames = new Dictionary<string, IBindingList>();
			m_ID3v23SingleOccurrenceFrames = new Dictionary<string, IFrame>();
			m_ID3v23MultipleOccurrenceFrames = new Dictionary<string, IBindingList>();
			m_ID3v22SingleOccurrenceFrames = new Dictionary<string, IFrame>();
			m_ID3v22MultipleOccurrenceFrames = new Dictionary<string, IBindingList>();
			m_ID3v24FrameAliases = new Dictionary<string, string>();
			m_ID3v23FrameAliases = new Dictionary<string, string>();
			m_AttachedPictureList = new AttachedPictureBindingList();
			m_UserDefinedUrlList = new UserDefinedUrlBindingList();
			m_CommentsList = new CommentsBindingList();
			m_CommercialInfoUrlList = new UrlBindingList("WCOM", "WCOM", "WCM");
			m_ArtistUrlList = new UrlBindingList("WOAR", "WOAR", "WAR");
			m_UserDefinedTextList = new UserDefinedTextBindingList();
			m_RelativeVolumeAdjustmentList = new RelativeVolumeAdjustmentBindingList();
			m_UnsynchronizedLyricsList = new UnsynchronizedLyricsBindingList();
			m_GeneralEncapsulatedObjectList = new GeneralEncapsulatedObjectBindingList();
			m_UniqueFileIdentifierList = new UniqueFileIdentifierBindingList();
			m_PrivateFrameList = new PrivateFrameBindingList();
			m_PopularimeterList = new PopularimeterBindingList();
			m_TermsOfUseList = new TermsOfUseBindingList();
			m_LinkedInformationList = new LinkedInformationBindingList();
			m_CommercialInfoList = new CommercialBindingList();
			m_EncryptionMethodList = new EncryptionMethodBindingList();
			m_GroupIdentificationList = new GroupIdentificationBindingList();
			m_SignatureList = new SignatureBindingList();
			m_AudioEncryptionList = new AudioEncryptionBindingList();
			m_EncryptedMetaFrameList = new EncryptedMetaFrameBindingList();
			m_SynchronizedLyricsList = new SynchronizedTextBindingList();
			m_EqualizationList = new EqualizationListBindingList();
			m_AudioTextList = new AudioTextBindingList();
			AddMultipleOccurrenceFrame("APIC", "APIC", "PIC", m_AttachedPictureList);
			AddMultipleOccurrenceFrame("WXXX", "WXXX", "WXX", m_UserDefinedUrlList);
			AddMultipleOccurrenceFrame("COMM", "COMM", "COM", m_CommentsList);
			AddMultipleOccurrenceFrame("WCOM", "WCOM", "WCM", m_CommercialInfoUrlList);
			AddMultipleOccurrenceFrame("WOAR", "WOAR", "WAR", m_ArtistUrlList);
			AddMultipleOccurrenceFrame("TXXX", "TXXX", "TXX", m_UserDefinedTextList);
			AddMultipleOccurrenceFrame("RVA2", "RVAD", "RVA", m_RelativeVolumeAdjustmentList);
			AddMultipleOccurrenceFrame("USLT", "USLT", "ULT", m_UnsynchronizedLyricsList);
			AddMultipleOccurrenceFrame("GEOB", "GEOB", "GEO", m_GeneralEncapsulatedObjectList);
			AddMultipleOccurrenceFrame("UFID", "UFID", "UFI", m_UniqueFileIdentifierList);
			AddMultipleOccurrenceFrame("PRIV", "PRIV", null, m_PrivateFrameList);
			AddMultipleOccurrenceFrame("POPM", "POPM", "POP", m_PopularimeterList);
			AddMultipleOccurrenceFrame("USER", "USER", null, m_TermsOfUseList);
			AddMultipleOccurrenceFrame("LINK", "LINK", "LNK", m_LinkedInformationList);
			AddMultipleOccurrenceFrame("AENC", "AENC", "CRA", m_AudioEncryptionList);
			AddMultipleOccurrenceFrame(null, null, "CRM", m_EncryptedMetaFrameList);
			AddMultipleOccurrenceFrame("SYLT", "SYLT", "SLT", m_SynchronizedLyricsList);
			AddMultipleOccurrenceFrame("EQU2", "EQUA", "EQU", m_EqualizationList);
			AddMultipleOccurrenceFrame("COMR", "COMR", null, m_CommercialInfoList);
			AddMultipleOccurrenceFrame("ENCR", "ENCR", null, m_EncryptionMethodList);
			AddMultipleOccurrenceFrame("GRID", "GRID", null, m_GroupIdentificationList);
			AddMultipleOccurrenceFrame("SIGN", "SIGN", null, m_SignatureList);
			AddMultipleOccurrenceFrame("ATXT", "ATXT", null, m_AudioTextList);
			m_Title = CreateTextFrame("TIT2", "TIT2", "TT2", "Title", null);
			m_Album = CreateTextFrame("TALB", "TALB", "TAL", "Album", null);
			m_EncodedByWho = CreateTextFrame("TENC", "TENC", "TEN", "EncodedByWho", null);
			m_Artist = CreateTextFrame("TPE1", "TPE1", "TP1", "Artist", null);
			m_Year = CreateTextFrame("TYER", "TYER", "TYE", "Year", ValidateYear);
			m_DateRecorded = CreateTextFrame("TDAT", "TDAT", "TDA", "DateRecorded", ValidateDateRecorded);
			m_TimeRecorded = CreateTextFrame("TIME", "TIME", "TIM", "TimeRecorded", ValidateTimeRecorded);
			m_Genre = CreateTextFrame("TCON", "TCON", "TCO", "Genre", null);
			m_Composer = CreateTextFrame("TCOM", "TCOM", "TCM", "Composer", null);
			m_OriginalArtist = CreateTextFrame("TOPE", "TOPE", "TOA", "OriginalArtist", null);
			m_Copyright = CreateTextFrame("TCOP", "TCOP", "TCR", "Copyright", ValidateCopyright);
			m_RemixedBy = CreateTextFrame("TPE4", "TPE4", "TP4", "RemixedBy", null);
			m_Publisher = CreateTextFrame("TPUB", "TPUB", "TPB", "Publisher", null);
			m_InternetRadioStationName = CreateTextFrame("TRSN", "TRSN", null, "InternetRadioStationName", null);
			m_InternetRadioStationOwner = CreateTextFrame("TRSO", "TRSO", null, "InternetRadioStationOwner", null);
			m_Accompaniment = CreateTextFrame("TPE2", "TPE2", "TP2", "Accompaniment", null);
			m_Conductor = CreateTextFrame("TPE3", "TPE3", "TP3", "Conductor", null);
			m_Lyricist = CreateTextFrame("TEXT", "TEXT", "TXT", "Lyricist", null);
			m_OriginalLyricist = CreateTextFrame("TOLY", "TOLY", "TOL", "OriginalLyricist", null);
			m_TrackNumber = CreateTextFrame("TRCK", "TRCK", "TRK", "TrackNumber", ValidateTrackNumber);
			m_BPM = CreateTextFrame("TBPM", "TBPM", "TBP", "BPM", ValidateBPM);
			m_FileType = CreateTextFrame("TFLT", "TFLT", "TFT", "FileType", null);
			m_DiscNumber = CreateTextFrame("TPOS", "TPOS", "TPA", "DiscNumber", ValidateDiscNumber);
			m_EncoderSettings = CreateTextFrame("TSSE", "TSSE", "TSS", "EncoderSettings", null);
			m_ISRC = CreateTextFrame("TSRC", "TSRC", "TRC", "ISRC", ValidateISRC);
			m_IsPartOfCompilation = CreateTextFrame("TCMP", "TCMP", "TCP", "IsPartOfCompilation", null);
			m_ReleaseTimestamp = CreateTextFrame("TDRL", "TDRL", null, "ReleaseTimestamp", ValidateReleaseTimestamp);
			m_RecordingTimestamp = CreateTextFrame("TDRC", "TDRC", null, "RecordingTimestamp", ValidateRecordingTimestamp);
			m_OriginalReleaseTimestamp = CreateTextFrame("TDOR", "TDOR", null, "OriginalReleaseTimestamp", null);
			m_PlaylistDelayMilliseconds = CreateTextFrame("TDLY", "TDLY", "TDY", "PlaylistDelayMilliseconds", null);
			m_InitialKey = CreateTextFrame("TKEY", "TKEY", "TKE", "InitialKey", null);
			m_EncodingTimestamp = CreateTextFrame("TDEN", "TDEN", null, "EncodingTimestamp", null);
			m_TaggingTimestamp = CreateTextFrame("TDTG", "TDTG", null, "TaggingTimestamp", null);
			m_ContentGroup = CreateTextFrame("TIT1", "TIT1", "TT1", "ContentGroup", null);
			m_Mood = CreateTextFrame("TMOO", "TMOO", null, "Mood", null);
			m_LengthMilliseconds = CreateTextFrame("TLEN", "TLEN", "TLE", "LengthMilliseconds", null);
			m_MediaType = CreateTextFrame("TMED", "TMED", "TMT", "MediaType", null);
			m_FileSizeExcludingTag = CreateTextFrame(null, "TSIZ", "TSI", "FileSizeExcludingTag", null);
			m_OriginalReleaseYear = CreateTextFrame("TORY", "TORY", "TOR", "OriginalReleaseYear", null);
			m_OriginalSourceTitle = CreateTextFrame("TOAL", "TOAL", "TOT", "OriginalSourceTitle", null);
			m_OriginalFileName = CreateTextFrame("TOFN", "TOFN", "TOF", "OriginalFileName", null);
			m_FileOwnerName = CreateTextFrame("TOWN", "TOWN", null, "FileOwnerName", null);
			m_RecordingDates = CreateTextFrame("TRDA", "TRDA", "TRD", "RecordingDates", null);
			m_Subtitle = CreateTextFrame("TIT3", "TIT3", "TT3", "Subtitle", null);
			m_AlbumSortOrder = CreateTextFrame("TSOA", "TSOA", null, "AlbumSortOrder", null);
			m_ArtistSortOrder = CreateTextFrame("TSOP", "TSOP", null, "ArtistSortOrder", null);
			m_TitleSortOrder = CreateTextFrame("TSOT", "TSOT", null, "TitleSortOrder", null);
			m_ProducedNotice = CreateTextFrame("TPRO", "TPRO", null, "ProducedNotice", null);
			m_SetSubtitle = CreateTextFrame("TSST", "TSST", null, "SetSubtitle", null);
			m_PositionSynchronization = CreatePositionSynchronizationFrame("POSS", "POSS", null, "PositionSynchronization", null);
			m_Ownership = CreateOwnershipFrame("OWNE", "OWNE", null, "Ownership", null);
			m_RecommendedBufferSize = CreateRecommendedBufferSizeFrame("RBUF", "RBUF", "BUF", "RecommendedBufferSize", null);
			m_InvolvedPersonList = CreateInvolvedPersonListFrame("TIPL", "IPLS", "IPL", "InvolvedPersonList", null);
			m_Languages = CreateLanguageFrame("TLAN", "TLAN", "TLA", "Languages", null);
			m_MusicCDIdentifier = CreateMusicCDIdentifierFrame("MCDI", "MCDI", "MCI", "MusicCDIdentifier", null);
			m_EventTiming = CreateEventTimingFrame("ETCO", "ETCO", "ETC", "EventTiming", null);
			m_MpegLookupTable = CreateMpegLookupTableFrame("MLLT", "MLLT", "MLL", "MpegLookupTable", null);
			m_Reverb = CreateReverbFrame("RVRB", "RVRB", "REV", "Reverb", null);
			m_SynchronizedTempoCodes = CreateSynchronizedTempoCodesFrame("SYTC", "SYTC", "STC", "SynchronizedTempoCodeList", null);
			m_SeekNextTag = CreateSeekFrame("SEEK", "SEEK", null, "SeekNextTag", null);
			m_MusicianCreditsList = CreateMusicianCreditsListFrame("TMCL", "TMCL", null, "MusicianCreditsList", null);
			m_AudioSeekPointIndex = CreateAudioSeekPointIndexFrame("ASPI", "ASPI", null, "AudioSeekPointIndex", null);
			m_PlayCount = CreateFrame<PlayCount>("PCNT", "PCNT", "CNT", "PlayCount");
			m_CopyrightUrl = CreateUrlFrame("WCOP", "WCOP", "WCP", "CopyrightUrl", ValidateCopyrightUrl);
			m_AudioFileUrl = CreateUrlFrame("WOAF", "WOAF", "WAF", "AudioFileUrl", ValidateAudioFileUrl);
			m_AudioSourceUrl = CreateUrlFrame("WOAS", "WOAS", "WAS", "AudioSourceUrl", ValidateAudioSourceUrl);
			m_InternetRadioStationUrl = CreateUrlFrame("WORS", "WORS", null, "InternetRadioStationUrl", ValidateInternetRadioStationUrl);
			m_PaymentUrl = CreateUrlFrame("WPAY", "WPAY", null, "PaymentUrl", ValidatePaymentUrl);
			m_PublisherUrl = CreateUrlFrame("WPUB", "WPUB", "WPB", "PublisherUrl", ValidatePublisherUrl);
			m_ID3v24FrameAliases.Add("RVAD", "RVA2");
			m_ID3v24FrameAliases.Add("IPLS", "TIPL");
			m_ID3v24FrameAliases.Add("EQUA", "EQU2");
			m_ID3v23FrameAliases.Add("RVA2", "RVAD");
			m_ID3v23FrameAliases.Add("TIPL", "IPLS");
			m_ID3v23FrameAliases.Add("EQU2", "EQUA");
		}

		private T CreateFrame<T>(string id3v24FrameID, string id3v23FrameID, string id3v22FrameID, string property) where T : IFrame, new()
		{
			T val = new T();
			Bind(id3v24FrameID, id3v23FrameID, id3v22FrameID, val, "TODO", property, null);
			return val;
		}

		private AudioSeekPointIndex CreateAudioSeekPointIndexFrame(string id3v24FrameID, string id3v23FrameID, string id3v22FrameID, string property, MethodInvoker validator)
		{
			AudioSeekPointIndex audioSeekPointIndex = new AudioSeekPointIndex();
			Bind(id3v24FrameID, id3v23FrameID, id3v22FrameID, audioSeekPointIndex, "TODO", property, validator);
			return audioSeekPointIndex;
		}

		private SynchronizedTempoCodes CreateSynchronizedTempoCodesFrame(string id3v24FrameID, string id3v23FrameID, string id3v22FrameID, string property, MethodInvoker validator)
		{
			SynchronizedTempoCodes synchronizedTempoCodes = new SynchronizedTempoCodes();
			Bind(id3v24FrameID, id3v23FrameID, id3v22FrameID, synchronizedTempoCodes, "TODO", property, validator);
			return synchronizedTempoCodes;
		}

		private Reverb CreateReverbFrame(string id3v24FrameID, string id3v23FrameID, string id3v22FrameID, string property, MethodInvoker validator)
		{
			Reverb reverb = new Reverb();
			Bind(id3v24FrameID, id3v23FrameID, id3v22FrameID, reverb, "TODO", property, validator);
			return reverb;
		}

		private MpegLookupTable CreateMpegLookupTableFrame(string id3v24FrameID, string id3v23FrameID, string id3v22FrameID, string property, MethodInvoker validator)
		{
			MpegLookupTable mpegLookupTable = new MpegLookupTable();
			Bind(id3v24FrameID, id3v23FrameID, id3v22FrameID, mpegLookupTable, "TODO", property, validator);
			return mpegLookupTable;
		}

		private EventTiming CreateEventTimingFrame(string id3v24FrameID, string id3v23FrameID, string id3v22FrameID, string property, MethodInvoker validator)
		{
			EventTiming eventTiming = new EventTiming();
			Bind(id3v24FrameID, id3v23FrameID, id3v22FrameID, eventTiming, "TODO", property, validator);
			return eventTiming;
		}

		private MusicianCreditsList CreateMusicianCreditsListFrame(string id3v24FrameID, string id3v23FrameID, string id3v22FrameID, string property, MethodInvoker validator)
		{
			MusicianCreditsList musicianCreditsList = new MusicianCreditsList();
			Bind(id3v24FrameID, id3v23FrameID, id3v22FrameID, musicianCreditsList, "TODO", property, validator);
			return musicianCreditsList;
		}

		private SeekNextTag CreateSeekFrame(string id3v24FrameID, string id3v23FrameID, string id3v22FrameID, string property, MethodInvoker validator)
		{
			SeekNextTag seekNextTag = new SeekNextTag();
			Bind(id3v24FrameID, id3v23FrameID, id3v22FrameID, seekNextTag, "TODO", property, validator);
			return seekNextTag;
		}

		private RecommendedBufferSize CreateRecommendedBufferSizeFrame(string id3v24FrameID, string id3v23FrameID, string id3v22FrameID, string property, MethodInvoker validator)
		{
			RecommendedBufferSize recommendedBufferSize = new RecommendedBufferSize();
			Bind(id3v24FrameID, id3v23FrameID, id3v22FrameID, recommendedBufferSize, "TODO", property, validator);
			return recommendedBufferSize;
		}

		private Ownership CreateOwnershipFrame(string id3v24FrameID, string id3v23FrameID, string id3v22FrameID, string property, MethodInvoker validator)
		{
			Ownership ownership = new Ownership();
			Bind(id3v24FrameID, id3v23FrameID, id3v22FrameID, ownership, "TODO", property, validator);
			return ownership;
		}

		private PositionSynchronization CreatePositionSynchronizationFrame(string id3v24FrameID, string id3v23FrameID, string id3v22FrameID, string property, MethodInvoker validator)
		{
			PositionSynchronization positionSynchronization = new PositionSynchronization();
			Bind(id3v24FrameID, id3v23FrameID, id3v22FrameID, positionSynchronization, "TODO", property, validator);
			return positionSynchronization;
		}

		private InvolvedPersonList CreateInvolvedPersonListFrame(string id3v24FrameID, string id3v23FrameID, string id3v22FrameID, string property, MethodInvoker validator)
		{
			InvolvedPersonList involvedPersonList = new InvolvedPersonList();
			Bind(id3v24FrameID, id3v23FrameID, id3v22FrameID, involvedPersonList, "TODO", property, validator);
			return involvedPersonList;
		}

		private void Bind(string id3v24FrameID, string id3v23FrameID, string id3v22FrameID, IFrame frame, string frameProperty, string property, MethodInvoker validator)
		{
			m_FrameBinder.Bind(frame, frameProperty, property, validator);
			if (id3v24FrameID != null)
			{
				m_ID3v24SingleOccurrenceFrames.Add(id3v24FrameID, frame);
			}
			if (id3v23FrameID != null)
			{
				m_ID3v23SingleOccurrenceFrames.Add(id3v23FrameID, frame);
			}
			if (id3v22FrameID != null)
			{
				m_ID3v22SingleOccurrenceFrames.Add(id3v22FrameID, frame);
			}
		}

		private MusicCDIdentifier CreateMusicCDIdentifierFrame(string id3v24FrameID, string id3v23FrameID, string id3v22FrameID, string property, MethodInvoker validator)
		{
			MusicCDIdentifier musicCDIdentifier = new MusicCDIdentifier();
			m_FrameBinder.Bind(musicCDIdentifier, "TOC", property, validator);
			if (id3v24FrameID != null)
			{
				m_ID3v24SingleOccurrenceFrames.Add(id3v24FrameID, musicCDIdentifier);
			}
			if (id3v23FrameID != null)
			{
				m_ID3v23SingleOccurrenceFrames.Add(id3v23FrameID, musicCDIdentifier);
			}
			if (id3v22FrameID != null)
			{
				m_ID3v22SingleOccurrenceFrames.Add(id3v22FrameID, musicCDIdentifier);
			}
			return musicCDIdentifier;
		}

		private LanguageFrame CreateLanguageFrame(string id3v24FrameID, string id3v23FrameID, string id3v22FrameID, string property, MethodInvoker validator)
		{
			LanguageFrame languageFrame = new LanguageFrame();
			m_FrameBinder.Bind(languageFrame, "Items", property, validator);
			if (id3v24FrameID != null)
			{
				m_ID3v24SingleOccurrenceFrames.Add(id3v24FrameID, languageFrame);
			}
			if (id3v23FrameID != null)
			{
				m_ID3v23SingleOccurrenceFrames.Add(id3v23FrameID, languageFrame);
			}
			if (id3v22FrameID != null)
			{
				m_ID3v22SingleOccurrenceFrames.Add(id3v22FrameID, languageFrame);
			}
			return languageFrame;
		}

		private void AddMultipleOccurrenceFrame(string id3v24FrameID, string id3v23FrameID, string id3v22FrameID, IBindingList bindingList)
		{
			if (id3v24FrameID != null)
			{
				m_ID3v24MultipleOccurrenceFrames.Add(id3v24FrameID, bindingList);
			}
			if (id3v23FrameID != null)
			{
				m_ID3v23MultipleOccurrenceFrames.Add(id3v23FrameID, bindingList);
			}
			if (id3v22FrameID != null)
			{
				m_ID3v22MultipleOccurrenceFrames.Add(id3v22FrameID, bindingList);
			}
		}

		private TextFrame CreateTextFrame(string id3v24FrameID, string id3v23FrameID, string id3v22FrameID, string property, MethodInvoker validator)
		{
			TextFrame textFrame = new TextFrame(id3v24FrameID, id3v23FrameID, id3v22FrameID);
			m_FrameBinder.Bind(textFrame, "Value", property, validator);
			if (id3v24FrameID != null)
			{
				m_ID3v24SingleOccurrenceFrames.Add(id3v24FrameID, textFrame);
			}
			if (id3v23FrameID != null)
			{
				m_ID3v23SingleOccurrenceFrames.Add(id3v23FrameID, textFrame);
			}
			if (id3v22FrameID != null)
			{
				m_ID3v22SingleOccurrenceFrames.Add(id3v22FrameID, textFrame);
			}
			return textFrame;
		}

		private UrlFrame CreateUrlFrame(string id3v24FrameID, string id3v23FrameID, string id3v22FrameID, string property, MethodInvoker validator)
		{
			UrlFrame urlFrame = new UrlFrame(id3v24FrameID, id3v23FrameID, id3v22FrameID);
			m_FrameBinder.Bind(urlFrame, "Value", property, validator);
			if (id3v24FrameID != null)
			{
				m_ID3v24SingleOccurrenceFrames.Add(id3v24FrameID, urlFrame);
			}
			if (id3v23FrameID != null)
			{
				m_ID3v23SingleOccurrenceFrames.Add(id3v23FrameID, urlFrame);
			}
			if (id3v22FrameID != null)
			{
				m_ID3v22SingleOccurrenceFrames.Add(id3v22FrameID, urlFrame);
			}
			return urlFrame;
		}

		private Dictionary<string, IFrame> GetSingleOccurrenceFrames(ID3v2TagVersion tagVersion)
		{
			return tagVersion switch
			{
				ID3v2TagVersion.ID3v23 => m_ID3v23SingleOccurrenceFrames, 
				ID3v2TagVersion.ID3v22 => m_ID3v22SingleOccurrenceFrames, 
				ID3v2TagVersion.ID3v24 => m_ID3v24SingleOccurrenceFrames, 
				_ => throw new ArgumentException("Unknown ID3v2 tag version"), 
			};
		}

		private Dictionary<string, IBindingList> GetMultipleOccurrenceFrames(ID3v2TagVersion tagVersion)
		{
			return tagVersion switch
			{
				ID3v2TagVersion.ID3v23 => m_ID3v23MultipleOccurrenceFrames, 
				ID3v2TagVersion.ID3v22 => m_ID3v22MultipleOccurrenceFrames, 
				ID3v2TagVersion.ID3v24 => m_ID3v24MultipleOccurrenceFrames, 
				_ => throw new ArgumentException("Unknown ID3v2 tag version"), 
			};
		}

		private void ValidateTimeRecorded()
		{
		}

		private void ValidateDateRecorded()
		{
		}

		private void ValidateRecordingTimestamp()
		{
			string recordingTimestamp = RecordingTimestamp;
			if (recordingTimestamp != null)
			{
				if (recordingTimestamp.Length >= 10)
				{
					DateRecorded = recordingTimestamp.Substring(5, 2) + recordingTimestamp.Substring(8, 2);
				}
				else if (recordingTimestamp.Length >= 7)
				{
					DateRecorded = recordingTimestamp.Substring(6, 2) + "00";
				}
				else
				{
					DateRecorded = null;
				}
				if (recordingTimestamp.Length >= 16)
				{
					TimeRecorded = recordingTimestamp.Substring(11, 2) + recordingTimestamp.Substring(14, 2);
				}
				else if (recordingTimestamp.Length >= 13)
				{
					TimeRecorded = recordingTimestamp.Substring(11, 2) + "00";
				}
				else
				{
					TimeRecorded = null;
				}
				if (recordingTimestamp.Length < 19)
				{
				}
			}
			else
			{
				DateRecorded = null;
				TimeRecorded = null;
			}
		}

		private void ValidateReleaseTimestamp()
		{
			string releaseTimestamp = ReleaseTimestamp;
			if (releaseTimestamp != null)
			{
				if (releaseTimestamp.Length >= 4)
				{
					Year = releaseTimestamp.Substring(0, 4);
				}
				else
				{
					Year = null;
				}
			}
			else
			{
				Year = null;
			}
		}

		private void ValidateISRC()
		{
			string iSRC = ISRC;
			if (!string.IsNullOrEmpty(iSRC) && iSRC.Length != 12)
			{
				FireWarning("ISRC", "ISRC value should be 12 characters in length");
			}
		}

		private void ValidateBPM()
		{
			string bPM = BPM;
			if (!string.IsNullOrEmpty(bPM) && !uint.TryParse(bPM, out var _))
			{
				FireWarning("BPM", "Value should be numeric");
			}
		}

		private void ValidateTrackNumber()
		{
			ValidateFractionValue("TrackNumber", TrackNumber, "Value should contain either the track number or track number/total tracks in the format ## or ##/##\nExample: 1 or 1/14");
		}

		private void ValidateDiscNumber()
		{
			ValidateFractionValue("DiscNumber", DiscNumber, "Value should contain either the disc number or disc number/total discs in the format ## or ##/##\nExample: 1 or 1/2");
		}

		private void ValidateFractionValue(string propertyName, string value, string message)
		{
			if (string.IsNullOrEmpty(value))
			{
				return;
			}
			bool flag = true;
			string[] array = value.Split('/');
			if (array.Length > 2)
			{
				flag = false;
			}
			else
			{
				int num = 0;
				uint num2 = 0u;
				uint num3 = 0u;
				string[] array2 = array;
				foreach (string s in array2)
				{
					if (!uint.TryParse(s, out var result))
					{
						flag = false;
						break;
					}
					switch (num)
					{
					case 0:
						num2 = result;
						break;
					case 1:
						num3 = result;
						break;
					}
					num++;
				}
				if (num2 == 0)
				{
					flag = false;
				}
				else if (num == 2 && num2 > num3)
				{
					flag = false;
				}
			}
			if (!flag)
			{
				FireWarning(propertyName, message);
			}
		}

		private void ValidateCopyright()
		{
			string copyright = Copyright;
			if (string.IsNullOrEmpty(copyright))
			{
				return;
			}
			bool flag = false;
			if (copyright.Length >= 6)
			{
				string s = copyright.Substring(0, 4);
				if (int.TryParse(s, out var result) && result >= 1000 && result <= 9999 && copyright[4] == ' ')
				{
					flag = true;
				}
			}
			if (!flag)
			{
				FireWarning("Copyright", $"The copyright field should begin with a year followed by the copyright owner{Environment.NewLine}Example: 2007 Sony Records");
			}
		}

		private void ValidateYear()
		{
			string year = Year;
			if (!string.IsNullOrEmpty(year) && (!int.TryParse(year, out var result) || result < 1000 || result >= 10000))
			{
				FireWarning("Year", $"The year field should be a 4 digit number{Environment.NewLine}Example: 2007");
			}
		}

		private void ValidateUrl(string propertyName, string value)
		{
			if (!string.IsNullOrEmpty(value) && !Uri.IsWellFormedUriString(value, UriKind.RelativeOrAbsolute))
			{
				FireWarning(propertyName, "Value is not a valid relative or absolute URL");
			}
		}

		private void ValidatePublisherUrl()
		{
			ValidateUrl("PublisherUrl", PublisherUrl);
		}

		private void ValidateCopyrightUrl()
		{
			ValidateUrl("CopyrightUrl", CopyrightUrl);
		}

		private void ValidatePaymentUrl()
		{
			ValidateUrl("PaymentUrl", PaymentUrl);
		}

		private void ValidateInternetRadioStationUrl()
		{
			ValidateUrl("InternetRadioStationUrl", InternetRadioStationUrl);
		}

		private void ValidateAudioSourceUrl()
		{
			ValidateUrl("AudioSourceUrl", AudioSourceUrl);
		}

		private void ValidateAudioFileUrl()
		{
			ValidateUrl("AudioFileUrl", AudioFileUrl);
		}

		protected void FireWarning(string propertyName, string message)
		{
			this.InvalidData?.Invoke(this, new InvalidDataEventArgs(propertyName, message));
		}

		public void Read(Stream stream, ID3v2TagVersion tagVersion, TagReadingInfo tmpTagReadingInfo, int tmpReadUntil, int tmpFrameIDSize)
		{
			Dictionary<string, IBindingList> multipleOccurrenceFrames = GetMultipleOccurrenceFrames(tagVersion);
			Dictionary<string, IFrame> singleOccurrenceFrames = GetSingleOccurrenceFrames(tagVersion);
			int num = 0;
			while (num < tmpReadUntil)
			{
				byte[] array = Utils.Read(stream, tmpFrameIDSize);
				switch (tmpFrameIDSize)
				{
				case 4:
					if (array[0] < 48 || array[0] > 90 || array[1] < 48 || array[1] > 90 || array[2] < 48 || array[2] > 90 || array[3] < 48 || array[3] > 90)
					{
						if (array[0] != 0 && array[0] != byte.MaxValue)
						{
							string text = $"Out of range FrameID - 0x{array[0]:X}|0x{array[1]:X}|0x{array[2]:X}|0x{array[3]:X}";
							if (Utils.ISO88591GetString(array) != "MP3e")
							{
								string text2 = Utils.ISO88591GetString(array);
								char[] trimChars = new char[1];
								string text3 = text2.TrimEnd(trimChars);
								Trace.WriteLine(text + " - " + text3);
							}
						}
						return;
					}
					goto default;
				case 3:
					if (array[0] < 48 || array[0] > 90 || array[1] < 48 || array[1] > 90 || array[2] < 48 || array[2] > 90)
					{
						if (array[0] != 0 && array[0] != byte.MaxValue)
						{
							string message = $"Out of range FrameID - 0x{array[0]:X}|0x{array[1]:X}|0x{array[2]:X}";
							Trace.WriteLine(message);
							Trace.WriteLine(Utils.ISO88591GetString(array));
						}
						return;
					}
					goto default;
				default:
				{
					string text4 = Utils.ISO88591GetString(array);
					IFrame value;
					do
					{
						if (singleOccurrenceFrames.TryGetValue(text4, out value))
						{
							value.Read(tmpTagReadingInfo, stream);
							num += value.FrameHeader.FrameSizeTotal;
							continue;
						}
						if (multipleOccurrenceFrames.TryGetValue(text4, out var value2))
						{
							value = (IFrame)value2.AddNew();
							value.Read(tmpTagReadingInfo, stream);
							num += value.FrameHeader.FrameSizeTotal;
							continue;
						}
						switch (tagVersion)
						{
						case ID3v2TagVersion.ID3v24:
						{
							if (!m_ID3v24FrameAliases.TryGetValue(text4, out var value4))
							{
								break;
							}
							text4 = value4;
							continue;
						}
						case ID3v2TagVersion.ID3v23:
						{
							if (!m_ID3v23FrameAliases.TryGetValue(text4, out var value3))
							{
								break;
							}
							text4 = value3;
							continue;
						}
						}
						break;
					}
					while (value == null);
					if (value == null)
					{
						if (text4 != "NCON" && text4 != "MJMD" && text4 != "TT22" && text4 != "PCST" && text4 != "TCAT" && text4 != "TKWD" && text4 != "TDES" && text4 != "TGID" && text4 != "WFED" && text4 != "CM1" && text4 != "TMB" && text4 != "RTNG" && text4 != "XDOR" && text4 != "XSOP")
						{
							_ = text4 != "TENK";
						}
						UnknownFrame unknownFrame = new UnknownFrame(text4, tmpTagReadingInfo, stream);
						m_UnknownFrames.Add(unknownFrame);
						num += unknownFrame.FrameHeader.FrameSizeTotal;
					}
					break;
				}
				}
			}
		}

		public byte[] GetBytes(ID3v2TagVersion tagVersion)
		{
			using MemoryStream memoryStream = new MemoryStream();
			Dictionary<string, IBindingList> multipleOccurrenceFrames = GetMultipleOccurrenceFrames(tagVersion);
			Dictionary<string, IFrame> singleOccurrenceFrames = GetSingleOccurrenceFrames(tagVersion);
			foreach (IFrame value in singleOccurrenceFrames.Values)
			{
				byte[] bytes = value.GetBytes(tagVersion);
				memoryStream.Write(bytes, 0, bytes.Length);
			}
			foreach (IBindingList value2 in multipleOccurrenceFrames.Values)
			{
				for (int i = 0; i < value2.Count; i++)
				{
					IFrame frame = (IFrame)value2[i];
					byte[] bytes2 = frame.GetBytes(tagVersion);
					memoryStream.Write(bytes2, 0, bytes2.Length);
				}
			}
			foreach (UnknownFrame unknownFrame in m_UnknownFrames)
			{
				byte[] bytes3 = unknownFrame.GetBytes(tagVersion);
				memoryStream.Write(bytes3, 0, bytes3.Length);
			}
			return memoryStream.ToArray();
		}

		public void FirePropertyChanged(string propertyName)
		{
			this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}

		public IFrameList GetFrameList(string frameID)
		{
			frameID = frameID.ToUpper();
			if (frameID == "APIC" || frameID == "PIC")
			{
				return m_AttachedPictureList;
			}
			return null;
		}
	}
}
