-- Table: public.CitiesForWeatherForecast

-- DROP TABLE IF EXISTS public."CitiesForWeatherForecast";

CREATE TABLE IF NOT EXISTS public."CitiesForWeatherForecast"
(
    "Id" integer NOT NULL DEFAULT nextval('"CitiesForWeatherForecast_id_seq"'::regclass),
    "Version" integer NOT NULL,
    "Key" text COLLATE pg_catalog."default" NOT NULL,
    "Type" text COLLATE pg_catalog."default",
    "Rank" integer,
    "LocalizedName" text COLLATE pg_catalog."default",
    "EnglishName" text COLLATE pg_catalog."default",
    "PrimaryPostalCode" text COLLATE pg_catalog."default",
    "Region" text COLLATE pg_catalog."default",
    "Country" text COLLATE pg_catalog."default",
    "AdministrativeArea" text COLLATE pg_catalog."default",
    "TimeZoneName" text COLLATE pg_catalog."default",
    "TimeZoneGmtOffset" double precision,
    "GeoPositionLatitude" double precision,
    "GeoPositionLongitude" double precision,
    "GeoPositionElevationMetric" double precision,
    "GeoPositionElevationImperial" double precision,
    "IsAlias" boolean,
    CONSTRAINT "CitiesForWeatherForecast_pkey" PRIMARY KEY ("Id")
)

TABLESPACE pg_default;

ALTER TABLE IF EXISTS public."CitiesForWeatherForecast"
    OWNER to postgres;

COMMENT ON TABLE public."CitiesForWeatherForecast"
    IS 'Таблица городов для прогноза погоды';