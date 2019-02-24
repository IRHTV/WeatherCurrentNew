using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace WeatherCurrent
{

    public class MeteoResult
    {

        // NOTE: Generated code may require at least .NET Framework 4.5 or .NET Core/Standard 2.0.
        /// <remarks/>
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://schema.feeds.meteonews.net")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://schema.feeds.meteonews.net", IsNullable = false)]
        public partial class forecasts
        {

            private forecastsParameters parametersField;

            private forecastsTimeperiod[] contentField;

            private object errorsField;

            private forecastsRef refField;

            /// <remarks/>
            public forecastsParameters parameters
            {
                get
                {
                    return this.parametersField;
                }
                set
                {
                    this.parametersField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlArrayItemAttribute("timeperiod", IsNullable = false)]
            public forecastsTimeperiod[] content
            {
                get
                {
                    return this.contentField;
                }
                set
                {
                    this.contentField = value;
                }
            }

            /// <remarks/>
            public object errors
            {
                get
                {
                    return this.errorsField;
                }
                set
                {
                    this.errorsField = value;
                }
            }

            /// <remarks/>
            public forecastsRef @ref
            {
                get
                {
                    return this.refField;
                }
                set
                {
                    this.refField = value;
                }
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://schema.feeds.meteonews.net")]
        public partial class forecastsParameters
        {

            private string langField;

            private string cumulationField;

            private string beginField;

            private string endField;

            private string idField;

            private string onEmptyField;

            /// <remarks/>
            public string lang
            {
                get
                {
                    return this.langField;
                }
                set
                {
                    this.langField = value;
                }
            }

            /// <remarks/>
            public string cumulation
            {
                get
                {
                    return this.cumulationField;
                }
                set
                {
                    this.cumulationField = value;
                }
            }

            /// <remarks/>
            public string begin
            {
                get
                {
                    return this.beginField;
                }
                set
                {
                    this.beginField = value;
                }
            }

            /// <remarks/>
            public string end
            {
                get
                {
                    return this.endField;
                }
                set
                {
                    this.endField = value;
                }
            }

            /// <remarks/>
            public string id
            {
                get
                {
                    return this.idField;
                }
                set
                {
                    this.idField = value;
                }
            }

            /// <remarks/>
            public string onEmpty
            {
                get
                {
                    return this.onEmptyField;
                }
                set
                {
                    this.onEmptyField = value;
                }
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://schema.feeds.meteonews.net")]
        public partial class forecastsTimeperiod
        {

            private forecastsTimeperiodTemp tempField;

            private forecastsTimeperiodTemp_avg temp_avgField;

            private forecastsTimeperiodTemp_min temp_minField;

            private forecastsTimeperiodTemp_max temp_maxField;

            private forecastsTimeperiodTemp_wind temp_windField;

            private forecastsTimeperiodTemp_5cm temp_5cmField;

            private forecastsTimeperiodTemp_m5cm temp_m5cmField;

            private forecastsTimeperiodTemp_m20cm temp_m20cmField;

            private forecastsTimeperiodTemp_m100cm temp_m100cmField;

            private forecastsTimeperiodWindforce windforceField;

            private forecastsTimeperiodWinddir winddirField;

            private forecastsTimeperiodGustforce gustforceField;

            private byte symbField;

            private string daynightField;

            private string txtField;

            private forecastsTimeperiodSun_prob sun_probField;

            private forecastsTimeperiodSun sunField;

            private forecastsTimeperiodPrecip_prob precip_probField;

            private forecastsTimeperiodPrecip precipField;

            private forecastsTimeperiodClouds cloudsField;

            private forecastsTimeperiodTemp_dew temp_dewField;

            private byte accurField;

            private forecastsTimeperiodHum humField;

            private forecastsTimeperiodEvapo evapoField;

            private forecastsTimeperiodPrecip_rangemin precip_rangeminField;

            private forecastsTimeperiodPrecip_rangemax precip_rangemaxField;

            private forecastsTimeperiodSnow_line snow_lineField;

            private forecastsTimeperiodFreez_level freez_levelField;

            private forecastsTimeperiodFog_level fog_levelField;

            private byte snow_on_road_indexField;

            private forecastsTimeperiodSnow snowField;

            private forecastsTimeperiodSnow_rangemin snow_rangeminField;

            private forecastsTimeperiodSnow_rangemax snow_rangemaxField;

            private forecastsTimeperiodGlob_rad glob_radField;

            private byte uvField;

            private forecastsTimeperiodPres presField;

            private string last_updateField;

            private forecastsTimeperiodTemp_mor temp_morField;

            private forecastsTimeperiodTemp_aft temp_aftField;

            private byte symb_morField;

            private byte symb_aftField;

            private string daynight_morField;

            private string daynight_aftField;

            private string txt_morField;

            private string txt_aftField;

            private string end_datetimeField;

            private byte cumulationField;

            /// <remarks/>
            public forecastsTimeperiodTemp temp
            {
                get
                {
                    return this.tempField;
                }
                set
                {
                    this.tempField = value;
                }
            }

            /// <remarks/>
            public forecastsTimeperiodTemp_avg temp_avg
            {
                get
                {
                    return this.temp_avgField;
                }
                set
                {
                    this.temp_avgField = value;
                }
            }

            /// <remarks/>
            public forecastsTimeperiodTemp_min temp_min
            {
                get
                {
                    return this.temp_minField;
                }
                set
                {
                    this.temp_minField = value;
                }
            }

            /// <remarks/>
            public forecastsTimeperiodTemp_max temp_max
            {
                get
                {
                    return this.temp_maxField;
                }
                set
                {
                    this.temp_maxField = value;
                }
            }

            /// <remarks/>
            public forecastsTimeperiodTemp_wind temp_wind
            {
                get
                {
                    return this.temp_windField;
                }
                set
                {
                    this.temp_windField = value;
                }
            }

            /// <remarks/>
            public forecastsTimeperiodTemp_5cm temp_5cm
            {
                get
                {
                    return this.temp_5cmField;
                }
                set
                {
                    this.temp_5cmField = value;
                }
            }

            /// <remarks/>
            public forecastsTimeperiodTemp_m5cm temp_m5cm
            {
                get
                {
                    return this.temp_m5cmField;
                }
                set
                {
                    this.temp_m5cmField = value;
                }
            }

            /// <remarks/>
            public forecastsTimeperiodTemp_m20cm temp_m20cm
            {
                get
                {
                    return this.temp_m20cmField;
                }
                set
                {
                    this.temp_m20cmField = value;
                }
            }

            /// <remarks/>
            public forecastsTimeperiodTemp_m100cm temp_m100cm
            {
                get
                {
                    return this.temp_m100cmField;
                }
                set
                {
                    this.temp_m100cmField = value;
                }
            }

            /// <remarks/>
            public forecastsTimeperiodWindforce windforce
            {
                get
                {
                    return this.windforceField;
                }
                set
                {
                    this.windforceField = value;
                }
            }

            /// <remarks/>
            public forecastsTimeperiodWinddir winddir
            {
                get
                {
                    return this.winddirField;
                }
                set
                {
                    this.winddirField = value;
                }
            }

            /// <remarks/>
            public forecastsTimeperiodGustforce gustforce
            {
                get
                {
                    return this.gustforceField;
                }
                set
                {
                    this.gustforceField = value;
                }
            }

            /// <remarks/>
            public byte symb
            {
                get
                {
                    return this.symbField;
                }
                set
                {
                    this.symbField = value;
                }
            }

            /// <remarks/>
            public string daynight
            {
                get
                {
                    return this.daynightField;
                }
                set
                {
                    this.daynightField = value;
                }
            }

            /// <remarks/>
            public string txt
            {
                get
                {
                    return this.txtField;
                }
                set
                {
                    this.txtField = value;
                }
            }

            /// <remarks/>
            public forecastsTimeperiodSun_prob sun_prob
            {
                get
                {
                    return this.sun_probField;
                }
                set
                {
                    this.sun_probField = value;
                }
            }

            /// <remarks/>
            public forecastsTimeperiodSun sun
            {
                get
                {
                    return this.sunField;
                }
                set
                {
                    this.sunField = value;
                }
            }

            /// <remarks/>
            public forecastsTimeperiodPrecip_prob precip_prob
            {
                get
                {
                    return this.precip_probField;
                }
                set
                {
                    this.precip_probField = value;
                }
            }

            /// <remarks/>
            public forecastsTimeperiodPrecip precip
            {
                get
                {
                    return this.precipField;
                }
                set
                {
                    this.precipField = value;
                }
            }

            /// <remarks/>
            public forecastsTimeperiodClouds clouds
            {
                get
                {
                    return this.cloudsField;
                }
                set
                {
                    this.cloudsField = value;
                }
            }

            /// <remarks/>
            public forecastsTimeperiodTemp_dew temp_dew
            {
                get
                {
                    return this.temp_dewField;
                }
                set
                {
                    this.temp_dewField = value;
                }
            }

            /// <remarks/>
            public byte accur
            {
                get
                {
                    return this.accurField;
                }
                set
                {
                    this.accurField = value;
                }
            }

            /// <remarks/>
            public forecastsTimeperiodHum hum
            {
                get
                {
                    return this.humField;
                }
                set
                {
                    this.humField = value;
                }
            }

            /// <remarks/>
            public forecastsTimeperiodEvapo evapo
            {
                get
                {
                    return this.evapoField;
                }
                set
                {
                    this.evapoField = value;
                }
            }

            /// <remarks/>
            public forecastsTimeperiodPrecip_rangemin precip_rangemin
            {
                get
                {
                    return this.precip_rangeminField;
                }
                set
                {
                    this.precip_rangeminField = value;
                }
            }

            /// <remarks/>
            public forecastsTimeperiodPrecip_rangemax precip_rangemax
            {
                get
                {
                    return this.precip_rangemaxField;
                }
                set
                {
                    this.precip_rangemaxField = value;
                }
            }

            /// <remarks/>
            public forecastsTimeperiodSnow_line snow_line
            {
                get
                {
                    return this.snow_lineField;
                }
                set
                {
                    this.snow_lineField = value;
                }
            }

            /// <remarks/>
            public forecastsTimeperiodFreez_level freez_level
            {
                get
                {
                    return this.freez_levelField;
                }
                set
                {
                    this.freez_levelField = value;
                }
            }

            /// <remarks/>
            public forecastsTimeperiodFog_level fog_level
            {
                get
                {
                    return this.fog_levelField;
                }
                set
                {
                    this.fog_levelField = value;
                }
            }

            /// <remarks/>
            public byte snow_on_road_index
            {
                get
                {
                    return this.snow_on_road_indexField;
                }
                set
                {
                    this.snow_on_road_indexField = value;
                }
            }

            /// <remarks/>
            public forecastsTimeperiodSnow snow
            {
                get
                {
                    return this.snowField;
                }
                set
                {
                    this.snowField = value;
                }
            }

            /// <remarks/>
            public forecastsTimeperiodSnow_rangemin snow_rangemin
            {
                get
                {
                    return this.snow_rangeminField;
                }
                set
                {
                    this.snow_rangeminField = value;
                }
            }

            /// <remarks/>
            public forecastsTimeperiodSnow_rangemax snow_rangemax
            {
                get
                {
                    return this.snow_rangemaxField;
                }
                set
                {
                    this.snow_rangemaxField = value;
                }
            }

            /// <remarks/>
            public forecastsTimeperiodGlob_rad glob_rad
            {
                get
                {
                    return this.glob_radField;
                }
                set
                {
                    this.glob_radField = value;
                }
            }

            /// <remarks/>
            public byte uv
            {
                get
                {
                    return this.uvField;
                }
                set
                {
                    this.uvField = value;
                }
            }

            /// <remarks/>
            public forecastsTimeperiodPres pres
            {
                get
                {
                    return this.presField;
                }
                set
                {
                    this.presField = value;
                }
            }

            /// <remarks/>
            public string last_update
            {
                get
                {
                    return this.last_updateField;
                }
                set
                {
                    this.last_updateField = value;
                }
            }

            /// <remarks/>
            public forecastsTimeperiodTemp_mor temp_mor
            {
                get
                {
                    return this.temp_morField;
                }
                set
                {
                    this.temp_morField = value;
                }
            }

            /// <remarks/>
            public forecastsTimeperiodTemp_aft temp_aft
            {
                get
                {
                    return this.temp_aftField;
                }
                set
                {
                    this.temp_aftField = value;
                }
            }

            /// <remarks/>
            public byte symb_mor
            {
                get
                {
                    return this.symb_morField;
                }
                set
                {
                    this.symb_morField = value;
                }
            }

            /// <remarks/>
            public byte symb_aft
            {
                get
                {
                    return this.symb_aftField;
                }
                set
                {
                    this.symb_aftField = value;
                }
            }

            /// <remarks/>
            public string daynight_mor
            {
                get
                {
                    return this.daynight_morField;
                }
                set
                {
                    this.daynight_morField = value;
                }
            }

            /// <remarks/>
            public string daynight_aft
            {
                get
                {
                    return this.daynight_aftField;
                }
                set
                {
                    this.daynight_aftField = value;
                }
            }

            /// <remarks/>
            public string txt_mor
            {
                get
                {
                    return this.txt_morField;
                }
                set
                {
                    this.txt_morField = value;
                }
            }

            /// <remarks/>
            public string txt_aft
            {
                get
                {
                    return this.txt_aftField;
                }
                set
                {
                    this.txt_aftField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string end_datetime
            {
                get
                {
                    return this.end_datetimeField;
                }
                set
                {
                    this.end_datetimeField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public byte cumulation
            {
                get
                {
                    return this.cumulationField;
                }
                set
                {
                    this.cumulationField = value;
                }
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://schema.feeds.meteonews.net")]
        public partial class forecastsTimeperiodTemp
        {

            private string unitField;

            private byte valueField;

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string unit
            {
                get
                {
                    return this.unitField;
                }
                set
                {
                    this.unitField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlTextAttribute()]
            public byte Value
            {
                get
                {
                    return this.valueField;
                }
                set
                {
                    this.valueField = value;
                }
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://schema.feeds.meteonews.net")]
        public partial class forecastsTimeperiodTemp_avg
        {

            private string unitField;

            private byte valueField;

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string unit
            {
                get
                {
                    return this.unitField;
                }
                set
                {
                    this.unitField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlTextAttribute()]
            public byte Value
            {
                get
                {
                    return this.valueField;
                }
                set
                {
                    this.valueField = value;
                }
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://schema.feeds.meteonews.net")]
        public partial class forecastsTimeperiodTemp_min
        {

            private string unitField;

            private byte valueField;

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string unit
            {
                get
                {
                    return this.unitField;
                }
                set
                {
                    this.unitField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlTextAttribute()]
            public byte Value
            {
                get
                {
                    return this.valueField;
                }
                set
                {
                    this.valueField = value;
                }
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://schema.feeds.meteonews.net")]
        public partial class forecastsTimeperiodTemp_max
        {

            private string unitField;

            private byte valueField;

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string unit
            {
                get
                {
                    return this.unitField;
                }
                set
                {
                    this.unitField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlTextAttribute()]
            public byte Value
            {
                get
                {
                    return this.valueField;
                }
                set
                {
                    this.valueField = value;
                }
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://schema.feeds.meteonews.net")]
        public partial class forecastsTimeperiodTemp_wind
        {

            private string unitField;

            private byte valueField;

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string unit
            {
                get
                {
                    return this.unitField;
                }
                set
                {
                    this.unitField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlTextAttribute()]
            public byte Value
            {
                get
                {
                    return this.valueField;
                }
                set
                {
                    this.valueField = value;
                }
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://schema.feeds.meteonews.net")]
        public partial class forecastsTimeperiodTemp_5cm
        {

            private string unitField;

            private byte valueField;

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string unit
            {
                get
                {
                    return this.unitField;
                }
                set
                {
                    this.unitField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlTextAttribute()]
            public byte Value
            {
                get
                {
                    return this.valueField;
                }
                set
                {
                    this.valueField = value;
                }
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://schema.feeds.meteonews.net")]
        public partial class forecastsTimeperiodTemp_m5cm
        {

            private string unitField;

            private byte valueField;

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string unit
            {
                get
                {
                    return this.unitField;
                }
                set
                {
                    this.unitField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlTextAttribute()]
            public byte Value
            {
                get
                {
                    return this.valueField;
                }
                set
                {
                    this.valueField = value;
                }
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://schema.feeds.meteonews.net")]
        public partial class forecastsTimeperiodTemp_m20cm
        {

            private string unitField;

            private byte valueField;

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string unit
            {
                get
                {
                    return this.unitField;
                }
                set
                {
                    this.unitField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlTextAttribute()]
            public byte Value
            {
                get
                {
                    return this.valueField;
                }
                set
                {
                    this.valueField = value;
                }
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://schema.feeds.meteonews.net")]
        public partial class forecastsTimeperiodTemp_m100cm
        {

            private string unitField;

            private byte valueField;

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string unit
            {
                get
                {
                    return this.unitField;
                }
                set
                {
                    this.unitField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlTextAttribute()]
            public byte Value
            {
                get
                {
                    return this.valueField;
                }
                set
                {
                    this.valueField = value;
                }
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://schema.feeds.meteonews.net")]
        public partial class forecastsTimeperiodWindforce
        {

            private byte rawField;

            private string unitField;

            private byte valueField;

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public byte raw
            {
                get
                {
                    return this.rawField;
                }
                set
                {
                    this.rawField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string unit
            {
                get
                {
                    return this.unitField;
                }
                set
                {
                    this.unitField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlTextAttribute()]
            public byte Value
            {
                get
                {
                    return this.valueField;
                }
                set
                {
                    this.valueField = value;
                }
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://schema.feeds.meteonews.net")]
        public partial class forecastsTimeperiodWinddir
        {

            private string unitField;

            private ushort valueField;

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string unit
            {
                get
                {
                    return this.unitField;
                }
                set
                {
                    this.unitField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlTextAttribute()]
            public ushort Value
            {
                get
                {
                    return this.valueField;
                }
                set
                {
                    this.valueField = value;
                }
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://schema.feeds.meteonews.net")]
        public partial class forecastsTimeperiodGustforce
        {

            private byte rawField;

            private string unitField;

            private byte valueField;

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public byte raw
            {
                get
                {
                    return this.rawField;
                }
                set
                {
                    this.rawField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string unit
            {
                get
                {
                    return this.unitField;
                }
                set
                {
                    this.unitField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlTextAttribute()]
            public byte Value
            {
                get
                {
                    return this.valueField;
                }
                set
                {
                    this.valueField = value;
                }
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://schema.feeds.meteonews.net")]
        public partial class forecastsTimeperiodSun_prob
        {

            private string unitField;

            private byte valueField;

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string unit
            {
                get
                {
                    return this.unitField;
                }
                set
                {
                    this.unitField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlTextAttribute()]
            public byte Value
            {
                get
                {
                    return this.valueField;
                }
                set
                {
                    this.valueField = value;
                }
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://schema.feeds.meteonews.net")]
        public partial class forecastsTimeperiodSun
        {

            private string unitField;

            private ushort valueField;

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string unit
            {
                get
                {
                    return this.unitField;
                }
                set
                {
                    this.unitField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlTextAttribute()]
            public ushort Value
            {
                get
                {
                    return this.valueField;
                }
                set
                {
                    this.valueField = value;
                }
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://schema.feeds.meteonews.net")]
        public partial class forecastsTimeperiodPrecip_prob
        {

            private string unitField;

            private byte valueField;

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string unit
            {
                get
                {
                    return this.unitField;
                }
                set
                {
                    this.unitField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlTextAttribute()]
            public byte Value
            {
                get
                {
                    return this.valueField;
                }
                set
                {
                    this.valueField = value;
                }
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://schema.feeds.meteonews.net")]
        public partial class forecastsTimeperiodPrecip
        {

            private string unitField;

            private byte valueField;

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string unit
            {
                get
                {
                    return this.unitField;
                }
                set
                {
                    this.unitField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlTextAttribute()]
            public byte Value
            {
                get
                {
                    return this.valueField;
                }
                set
                {
                    this.valueField = value;
                }
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://schema.feeds.meteonews.net")]
        public partial class forecastsTimeperiodClouds
        {

            private string unitField;

            private byte valueField;

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string unit
            {
                get
                {
                    return this.unitField;
                }
                set
                {
                    this.unitField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlTextAttribute()]
            public byte Value
            {
                get
                {
                    return this.valueField;
                }
                set
                {
                    this.valueField = value;
                }
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://schema.feeds.meteonews.net")]
        public partial class forecastsTimeperiodTemp_dew
        {

            private string unitField;

            private byte valueField;

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string unit
            {
                get
                {
                    return this.unitField;
                }
                set
                {
                    this.unitField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlTextAttribute()]
            public byte Value
            {
                get
                {
                    return this.valueField;
                }
                set
                {
                    this.valueField = value;
                }
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://schema.feeds.meteonews.net")]
        public partial class forecastsTimeperiodHum
        {

            private string unitField;

            private byte valueField;

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string unit
            {
                get
                {
                    return this.unitField;
                }
                set
                {
                    this.unitField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlTextAttribute()]
            public byte Value
            {
                get
                {
                    return this.valueField;
                }
                set
                {
                    this.valueField = value;
                }
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://schema.feeds.meteonews.net")]
        public partial class forecastsTimeperiodEvapo
        {

            private string unitField;

            private decimal valueField;

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string unit
            {
                get
                {
                    return this.unitField;
                }
                set
                {
                    this.unitField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlTextAttribute()]
            public decimal Value
            {
                get
                {
                    return this.valueField;
                }
                set
                {
                    this.valueField = value;
                }
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://schema.feeds.meteonews.net")]
        public partial class forecastsTimeperiodPrecip_rangemin
        {

            private string unitField;

            private byte valueField;

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string unit
            {
                get
                {
                    return this.unitField;
                }
                set
                {
                    this.unitField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlTextAttribute()]
            public byte Value
            {
                get
                {
                    return this.valueField;
                }
                set
                {
                    this.valueField = value;
                }
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://schema.feeds.meteonews.net")]
        public partial class forecastsTimeperiodPrecip_rangemax
        {

            private string unitField;

            private byte valueField;

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string unit
            {
                get
                {
                    return this.unitField;
                }
                set
                {
                    this.unitField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlTextAttribute()]
            public byte Value
            {
                get
                {
                    return this.valueField;
                }
                set
                {
                    this.valueField = value;
                }
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://schema.feeds.meteonews.net")]
        public partial class forecastsTimeperiodSnow_line
        {

            private string unitField;

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string unit
            {
                get
                {
                    return this.unitField;
                }
                set
                {
                    this.unitField = value;
                }
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://schema.feeds.meteonews.net")]
        public partial class forecastsTimeperiodFreez_level
        {

            private string unitField;

            private byte groundField;

            private ushort valueField;

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string unit
            {
                get
                {
                    return this.unitField;
                }
                set
                {
                    this.unitField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public byte ground
            {
                get
                {
                    return this.groundField;
                }
                set
                {
                    this.groundField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlTextAttribute()]
            public ushort Value
            {
                get
                {
                    return this.valueField;
                }
                set
                {
                    this.valueField = value;
                }
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://schema.feeds.meteonews.net")]
        public partial class forecastsTimeperiodFog_level
        {

            private string unitField;

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string unit
            {
                get
                {
                    return this.unitField;
                }
                set
                {
                    this.unitField = value;
                }
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://schema.feeds.meteonews.net")]
        public partial class forecastsTimeperiodSnow
        {

            private string unitField;

            private byte valueField;

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string unit
            {
                get
                {
                    return this.unitField;
                }
                set
                {
                    this.unitField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlTextAttribute()]
            public byte Value
            {
                get
                {
                    return this.valueField;
                }
                set
                {
                    this.valueField = value;
                }
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://schema.feeds.meteonews.net")]
        public partial class forecastsTimeperiodSnow_rangemin
        {

            private string unitField;

            private byte valueField;

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string unit
            {
                get
                {
                    return this.unitField;
                }
                set
                {
                    this.unitField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlTextAttribute()]
            public byte Value
            {
                get
                {
                    return this.valueField;
                }
                set
                {
                    this.valueField = value;
                }
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://schema.feeds.meteonews.net")]
        public partial class forecastsTimeperiodSnow_rangemax
        {

            private string unitField;

            private byte valueField;

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string unit
            {
                get
                {
                    return this.unitField;
                }
                set
                {
                    this.unitField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlTextAttribute()]
            public byte Value
            {
                get
                {
                    return this.valueField;
                }
                set
                {
                    this.valueField = value;
                }
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://schema.feeds.meteonews.net")]
        public partial class forecastsTimeperiodGlob_rad
        {

            private string unitField;

            private ushort valueField;

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string unit
            {
                get
                {
                    return this.unitField;
                }
                set
                {
                    this.unitField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlTextAttribute()]
            public ushort Value
            {
                get
                {
                    return this.valueField;
                }
                set
                {
                    this.valueField = value;
                }
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://schema.feeds.meteonews.net")]
        public partial class forecastsTimeperiodPres
        {

            private string unitField;

            private ushort valueField;

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string unit
            {
                get
                {
                    return this.unitField;
                }
                set
                {
                    this.unitField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlTextAttribute()]
            public ushort Value
            {
                get
                {
                    return this.valueField;
                }
                set
                {
                    this.valueField = value;
                }
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://schema.feeds.meteonews.net")]
        public partial class forecastsTimeperiodTemp_mor
        {

            private string unitField;

            private byte valueField;

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string unit
            {
                get
                {
                    return this.unitField;
                }
                set
                {
                    this.unitField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlTextAttribute()]
            public byte Value
            {
                get
                {
                    return this.valueField;
                }
                set
                {
                    this.valueField = value;
                }
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://schema.feeds.meteonews.net")]
        public partial class forecastsTimeperiodTemp_aft
        {

            private string unitField;

            private byte valueField;

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string unit
            {
                get
                {
                    return this.unitField;
                }
                set
                {
                    this.unitField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlTextAttribute()]
            public byte Value
            {
                get
                {
                    return this.valueField;
                }
                set
                {
                    this.valueField = value;
                }
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://schema.feeds.meteonews.net")]
        public partial class forecastsRef
        {

            private string urlField;

            private string valueField;

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string url
            {
                get
                {
                    return this.urlField;
                }
                set
                {
                    this.urlField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlTextAttribute()]
            public string Value
            {
                get
                {
                    return this.valueField;
                }
                set
                {
                    this.valueField = value;
                }
            }
        }


    }
}