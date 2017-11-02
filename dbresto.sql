-- phpMyAdmin SQL Dump
-- version 3.2.0.1
-- http://www.phpmyadmin.net
--
-- Host: localhost
-- Waktu pembuatan: 02. Nopember 2017 jam 20:21
-- Versi Server: 5.1.22
-- Versi PHP: 5.3.0

SET SQL_MODE="NO_AUTO_VALUE_ON_ZERO";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;

--
-- Database: `dbresto`
--

-- --------------------------------------------------------

--
-- Struktur dari tabel `cafe`
--

CREATE TABLE IF NOT EXISTS `cafe` (
  `idkedai` int(11) DEFAULT NULL,
  `idmenu` varchar(7) DEFAULT NULL,
  `namamenu` varchar(30) DEFAULT NULL,
  `harga` double DEFAULT NULL,
  `banyak` int(11) DEFAULT NULL,
  `subtotal` double DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data untuk tabel `cafe`
--

INSERT INTO `cafe` (`idkedai`, `idmenu`, `namamenu`, `harga`, `banyak`, `subtotal`) VALUES
(1, 'MKABK02', 'Ayam Bakar Bumbu Kecap', 12000, 2, 24000),
(1, 'MKASB01', 'Asem-asem Buntut', 15000, 2, 30000),
(2, 'MKABK02', 'Ayam Bakar Bumbu Kecap', 12000, 2, 24000),
(2, 'MKASB01', 'Asem-asem Buntut', 15000, 1, 15000);

-- --------------------------------------------------------

--
-- Struktur dari tabel `disk`
--

CREATE TABLE IF NOT EXISTS `disk` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `disko` double DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=5 ;

--
-- Dumping data untuk tabel `disk`
--

INSERT INTO `disk` (`id`, `disko`) VALUES
(1, 5),
(2, 8),
(3, 10),
(4, 15);

-- --------------------------------------------------------

--
-- Struktur dari tabel `grup`
--

CREATE TABLE IF NOT EXISTS `grup` (
  `notrans` int(11) DEFAULT NULL,
  `idkamar` varchar(7) DEFAULT NULL,
  `namakamar` varchar(30) DEFAULT NULL,
  `lama` int(11) DEFAULT NULL,
  `harga` double DEFAULT NULL,
  `hargadiskon` double DEFAULT NULL,
  `kedai` double DEFAULT NULL,
  `lain` double DEFAULT NULL,
  `subtotal` double DEFAULT NULL,
  `total` double DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data untuk tabel `grup`
--

INSERT INTO `grup` (`notrans`, `idkamar`, `namakamar`, `lama`, `harga`, `hargadiskon`, `kedai`, `lain`, `subtotal`, `total`) VALUES
(1, 'FMSP102', 'Family Superior', 1, 400000, 20000, 0, 0, 380000, 760000),
(1, 'FMSP105', 'Family Superior', 1, 400000, 20000, 0, 0, 380000, 760000),
(2, 'BSFM120', 'Bussines Superior', 1, 350000, 17500, 0, 0, 332500, 712500),
(2, 'FMSP101', 'Family Superior', 1, 400000, 20000, 0, 0, 380000, 712500);

-- --------------------------------------------------------

--
-- Struktur dari tabel `kamar`
--

CREATE TABLE IF NOT EXISTS `kamar` (
  `idkamar` varchar(7) NOT NULL,
  `namakamar` varchar(30) DEFAULT NULL,
  `harga` double DEFAULT NULL,
  PRIMARY KEY (`idkamar`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data untuk tabel `kamar`
--

INSERT INTO `kamar` (`idkamar`, `namakamar`, `harga`) VALUES
('BSFM120', 'Bussines Superior', 350000),
('FMSP101', 'Family Superior', 400000),
('FMSP102', 'Family Superior', 400000),
('FMSP103', 'Family Superior', 400000),
('FMSP104', 'Family Superior', 400000),
('FMSP105', 'Family Superior', 400000);

-- --------------------------------------------------------

--
-- Struktur dari tabel `kedai`
--

CREATE TABLE IF NOT EXISTS `kedai` (
  `idkedai` int(11) NOT NULL AUTO_INCREMENT,
  `idpelanggan` varchar(9) DEFAULT NULL,
  `tanggal` varchar(10) DEFAULT NULL,
  `bayarkedai` double DEFAULT NULL,
  PRIMARY KEY (`idkedai`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=3 ;

--
-- Dumping data untuk tabel `kedai`
--

INSERT INTO `kedai` (`idkedai`, `idpelanggan`, `tanggal`, `bayarkedai`) VALUES
(1, 'IP00001', '18/12/2014', 54000),
(2, 'IP00001', '18/12/2014', 39000);

-- --------------------------------------------------------

--
-- Struktur dari tabel `menu`
--

CREATE TABLE IF NOT EXISTS `menu` (
  `idmenu` varchar(7) NOT NULL,
  `namamenu` varchar(30) DEFAULT NULL,
  `harga` double DEFAULT NULL,
  PRIMARY KEY (`idmenu`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data untuk tabel `menu`
--

INSERT INTO `menu` (`idmenu`, `namamenu`, `harga`) VALUES
('MKABK02', 'Ayam Bakar Bumbu Kecap', 12000),
('MKASB01', 'Asem-asem Buntut', 15000);

-- --------------------------------------------------------

--
-- Struktur dari tabel `pelanggan`
--

CREATE TABLE IF NOT EXISTS `pelanggan` (
  `idpelanggan` varchar(9) NOT NULL,
  `namapelanggan` varchar(40) NOT NULL,
  `alamat` varchar(40) NOT NULL,
  PRIMARY KEY (`idpelanggan`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data untuk tabel `pelanggan`
--

INSERT INTO `pelanggan` (`idpelanggan`, `namapelanggan`, `alamat`) VALUES
('IP00001', 'Arman', 'Surabaya'),
('IP00002', 'Nur', 'Lamongan');

-- --------------------------------------------------------

--
-- Struktur dari tabel `transaksi`
--

CREATE TABLE IF NOT EXISTS `transaksi` (
  `nokuitansi` int(11) NOT NULL AUTO_INCREMENT,
  `namapelanggan` varchar(40) DEFAULT NULL,
  `idkamar` varchar(7) DEFAULT NULL,
  `namakamar` varchar(30) DEFAULT NULL,
  `tanggalmasuk` varchar(15) DEFAULT NULL,
  `tanggalkeluar` varchar(15) DEFAULT NULL,
  `lama` int(11) DEFAULT NULL,
  `harga` double DEFAULT NULL,
  `subtotal` double DEFAULT NULL,
  `hargadiskon` double DEFAULT NULL,
  `kedai` double DEFAULT NULL,
  `lain` double DEFAULT NULL,
  `total` double DEFAULT NULL,
  PRIMARY KEY (`nokuitansi`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=3 ;

--
-- Dumping data untuk tabel `transaksi`
--

INSERT INTO `transaksi` (`nokuitansi`, `namapelanggan`, `idkamar`, `namakamar`, `tanggalmasuk`, `tanggalkeluar`, `lama`, `harga`, `subtotal`, `hargadiskon`, `kedai`, `lain`, `total`) VALUES
(1, 'Arman', 'FMSP102', 'Family Superior', '15/12/2014', '16/12/2014', 1, 400000, 400000, 28000, 0, 0, 372000),
(2, 'Nur', 'FMSP101', 'Family Superior', '15/12/2014', '15/12/2014', 1, 400000, 400000, 20000, 0, 0, 380000);
