-- --------------------------------------------------------
-- Sunucu:                       93.89.225.198
-- Sunucu sürümü:                5.7.30 - MySQL Community Server (GPL)
-- Sunucu İşletim Sistemi:       Win64
-- HeidiSQL Sürüm:               12.5.0.6677
-- --------------------------------------------------------

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET NAMES utf8 */;
/*!50503 SET NAMES utf8mb4 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

-- tablo yapısı dökülüyor pmitln2oq_db0001.blog
DROP TABLE IF EXISTS `blog`;
CREATE TABLE IF NOT EXISTS `blog` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `title` varchar(250) DEFAULT NULL,
  `subtitle` varchar(500) DEFAULT NULL,
  `detail` longtext,
  `isview` tinyint(1) DEFAULT NULL,
  `date` datetime DEFAULT NULL,
  `like` int(11) DEFAULT NULL,
  `read` int(11) DEFAULT NULL,
  `image` varchar(250) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8;

-- pmitln2oq_db0001.blog: ~3 rows (yaklaşık) tablosu için veriler indiriliyor
DELETE FROM `blog`;
INSERT INTO `blog` (`id`, `title`, `subtitle`, `detail`, `isview`, `date`, `like`, `read`, `image`) VALUES
	(1, 'Blog başlık', 'blog alt başlık,', 'A small river named Duden flows by their place and supplies it with the necessary', 1, '2023-06-10 10:25:34', 0, 0, 'blog-1.jpg'),
	(2, 'Manchester City - Inter maçı ne zaman, saat kaçta ve hangi kanalda?', 'Şampiyonlar Ligi\'nde 2022-2023 sezonunun şampiyonu, Manchester City ile Inter arasında bu akşam İstanbul\'da oynanacak finalde belli olacak. Manchester City ilk, Inter 4. şampiyonluğunu hedefliyor. Öte yandan Şampiyonlar Ligi kupası tarihte ilk kez bir Türk futbolcunun elinde yükselecek. Peki Manchester City - Inter maçı saat kaçta hangi kanalda? İşte tüm detaylar', 'Şampiyonlar Ligi\'nde 2022-2023 sezonunun şampiyonu, Manchester City ile Inter arasında bu akşam İstanbul\'da oynanacak finalde belli olacak. Manchester City ilk, Inter 4. şampiyonluğunu hedefliyor. Öte yandan Şampiyonlar Ligi kupası tarihte ilk kez bir Türk futbolcunun elinde yükselecek. Peki Manchester City - Inter maçı saat kaçta hangi kanalda? İşte tüm detaylar', 1, '2023-06-10 12:32:13', 5, 10, 'blog-2.jpg'),
	(3, 'dssdfsd', 'sdfsdf', 'sdfdfd', 1, '2023-06-11 10:58:13', 0, 0, 'blog-3.jpg');

-- tablo yapısı dökülüyor pmitln2oq_db0001.comment
DROP TABLE IF EXISTS `comment`;
CREATE TABLE IF NOT EXISTS `comment` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `type` varchar(50) DEFAULT NULL,
  `typeid` int(11) DEFAULT NULL,
  `name` varchar(100) DEFAULT NULL,
  `lastname` varchar(100) DEFAULT NULL,
  `email` varchar(250) DEFAULT NULL,
  `date` datetime DEFAULT NULL,
  `message` text,
  `isview` tinyint(1) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=20 DEFAULT CHARSET=utf8;

-- pmitln2oq_db0001.comment: ~16 rows (yaklaşık) tablosu için veriler indiriliyor
DELETE FROM `comment`;
INSERT INTO `comment` (`id`, `type`, `typeid`, `name`, `lastname`, `email`, `date`, `message`, `isview`) VALUES
	(1, 'blog', 2, 'Mehmet', 'Sular', 'mksular@gmail.com', '2023-07-15 11:55:17', 'hgjhgjh', 1),
	(2, 'blog', 2, 'Mustafa', 'Tanuğur', 'mustafa@gmail.com', '2023-07-15 11:56:42', 'deneme amaçlıdır', 1),
	(3, 'blog', 2, 'Özkan', 'Yılmaz', 'ozkanyilmaz@outlook.com.tr', '2023-07-15 11:56:37', 'merhaba', 0),
	(4, 'event', 2, 'Özkan', 'Yılmaz', 'ozkanyilmaz@outlook.com.tr', '2023-07-15 12:35:04', 'Sergi ve etkinlikler yorum deneme', 0),
	(5, 'event', 2, 'mustafa', 'hakan', 'mustafa@gmail.com', '2023-07-15 12:46:04', 'mıuasakdada', 1),
	(7, 'blog', 2, 'Bilge', 'Kağan', 'ersin@uxyazilim.com', '2023-07-15 13:29:53', 'Biz bunu taşa yazardık', 1),
	(8, 'event', 2, 'Kral ', 'Akhenaton', 'ersin@uxyazilim.com', '2023-07-15 16:19:01', 'Biz bunları parşömenlere yazardık', 0),
	(9, 'event', 2, 'Ersin', 'Tezcan', 'info@seondex.com', '2023-07-15 17:07:48', 'Test', 0),
	(10, 'event', 2, 'Bilge ', 'Kağan', 'ersin@uxyazilim.com', '2023-07-15 17:09:12', 'Biz yorumu taşlara yazardık', 1),
	(11, 'event', 2, '4.', 'Ramses', 'ersin@uxyazilim.com', '2023-07-15 17:10:49', 'Hep geri kaldın Bilge Kağan, biz yorumu parşömenlere yazardık hacı', 1),
	(12, 'work', 2, 'Ersin', 'Tezcan', 'info@seondex.com', '2023-07-15 22:20:24', 'rwst', 0),
	(13, 'work', 2, 'Bilge ', 'Kağan', 'bilge@gmail.com', '2023-07-15 22:59:45', 'Biz bunu taşa yazardık', 1),
	(14, 'work', 2, 'Betul', 'Sattary', 'b.s.sattari@gmail.com', '2023-07-15 23:17:19', 'Basardim', 0),
	(15, 'work', 2, 'Betul', 'Sattary', 'b.s.sattari@gmail.com', '2023-07-15 23:19:53', 'sonunda basardim', 0),
	(16, 'work', 2, 'ALİREZA', 'KHATAEE', 'ar_khataee@yahoo.com', '2023-07-22 10:56:40', 'sfergr', 0),
	(17, 'work', 2, 'Mehmet', 'Sular', 'mksular@gmail.com', '2023-07-22 10:56:50', 'eseri beğenmedim', 1),
	(18, 'work', 2, 'Ersin', 'Tezcan', 'alonepartizan@gmail.com', '2023-07-23 09:56:46', 'test', 0),
	(19, 'blog', 2, 'Ersin', 'Tezcan', 'alonepartizan@gmail.com', '2023-07-23 10:08:35', 'test', 0);

-- tablo yapısı dökülüyor pmitln2oq_db0001.event
DROP TABLE IF EXISTS `event`;
CREATE TABLE IF NOT EXISTS `event` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `title` varchar(250) DEFAULT NULL,
  `subtitle` varchar(500) DEFAULT NULL,
  `detail` longtext,
  `isview` tinyint(1) DEFAULT NULL,
  `date` datetime DEFAULT NULL,
  `like` int(11) DEFAULT NULL,
  `read` int(11) DEFAULT NULL,
  `image` varchar(250) DEFAULT NULL,
  `dateend` datetime DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8;

-- pmitln2oq_db0001.event: ~3 rows (yaklaşık) tablosu için veriler indiriliyor
DELETE FROM `event`;
INSERT INTO `event` (`id`, `title`, `subtitle`, `detail`, `isview`, `date`, `like`, `read`, `image`, `dateend`) VALUES
	(1, 'Blog başlık', 'blog alt başlık,', 'A small river named Duden flows by their place and supplies it with the necessary', 1, '2023-06-10 10:25:34', 0, 0, 'blog-1.jpg', '2023-07-15 11:17:05'),
	(2, 'Manchester City - Inter maçı ne zaman, saat kaçta ve hangi kanalda?', 'Şampiyonlar Ligi\'nde 2022-2023 sezonunun şampiyonu, Manchester City ile Inter arasında bu akşam İstanbul\'da oynanacak finalde belli olacak. Manchester City ilk, Inter 4. şampiyonluğunu hedefliyor. Öte yandan Şampiyonlar Ligi kupası tarihte ilk kez bir Türk futbolcunun elinde yükselecek. Peki Manchester City - Inter maçı saat kaçta hangi kanalda? İşte tüm detaylar', 'Şampiyonlar Ligi\'nde 2022-2023 sezonunun şampiyonu, Manchester City ile Inter arasında bu akşam İstanbul\'da oynanacak finalde belli olacak. Manchester City ilk, Inter 4. şampiyonluğunu hedefliyor. Öte yandan Şampiyonlar Ligi kupası tarihte ilk kez bir Türk futbolcunun elinde yükselecek. Peki Manchester City - Inter maçı saat kaçta hangi kanalda? İşte tüm detaylar', 1, '2023-06-10 12:32:13', 5, 10, 'blog-2.jpg', '2023-07-15 11:17:07'),
	(3, 'dssdfsd', 'sdfsdf', 'sdfdfd', 1, '2023-06-11 10:58:13', 0, 0, 'blog-3.jpg', '2023-07-15 11:17:08');

-- tablo yapısı dökülüyor pmitln2oq_db0001.like
DROP TABLE IF EXISTS `like`;
CREATE TABLE IF NOT EXISTS `like` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `type` varchar(50) DEFAULT NULL,
  `typeid` int(11) DEFAULT NULL,
  `ip` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=utf8;

-- pmitln2oq_db0001.like: ~1 rows (yaklaşık) tablosu için veriler indiriliyor
DELETE FROM `like`;
INSERT INTO `like` (`id`, `type`, `typeid`, `ip`) VALUES
	(8, 'work', 2, '::1');

-- tablo yapısı dökülüyor pmitln2oq_db0001.site
DROP TABLE IF EXISTS `site`;
CREATE TABLE IF NOT EXISTS `site` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(250) DEFAULT NULL,
  `title` varchar(250) DEFAULT NULL,
  `description` text,
  `keywords` text,
  `url` varchar(250) DEFAULT NULL,
  `email` varchar(250) DEFAULT NULL,
  `logo` varchar(250) DEFAULT NULL,
  `logo2` varchar(250) DEFAULT NULL,
  `favicon` varchar(250) DEFAULT NULL,
  `page` int(11) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;

-- pmitln2oq_db0001.site: ~0 rows (yaklaşık) tablosu için veriler indiriliyor
DELETE FROM `site`;
INSERT INTO `site` (`id`, `name`, `title`, `description`, `keywords`, `url`, `email`, `logo`, `logo2`, `favicon`, `page`) VALUES
	(1, 'Mitorya', 'Mitorya |  Duvar Sanatı - Grafiti', 'Mitorya 2010 yılından itibaren adana\'da grafiti üzerine ve tuval çalışmalrıyla billinen bir sanatçıdır.', 'grafiti, tuval, resim, sanat, art, duvar sanatı', 'www.mitorya.com.tr', 'info@mitorya.com.tr', 'logo.png', 'logo2.png', 'favicon.png', 2);

-- tablo yapısı dökülüyor pmitln2oq_db0001.slide
DROP TABLE IF EXISTS `slide`;
CREATE TABLE IF NOT EXISTS `slide` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `title` varchar(250) DEFAULT NULL,
  `subtitle` varchar(250) DEFAULT NULL,
  `image` varchar(250) DEFAULT NULL,
  `url` varchar(250) DEFAULT NULL,
  `target` varchar(50) DEFAULT NULL,
  `isview` tinyint(1) DEFAULT NULL,
  `order` int(11) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8;

-- pmitln2oq_db0001.slide: ~2 rows (yaklaşık) tablosu için veriler indiriliyor
DELETE FROM `slide`;
INSERT INTO `slide` (`id`, `title`, `subtitle`, `image`, `url`, `target`, `isview`, `order`) VALUES
	(1, 'Hello World', '20 March 2018', 'img_bg_1.jpg', '/event', '_self', 1, 1),
	(2, 'How a website designer began customizing and designing', '20 March 2018', 'img_bg_2.jpg', '/blog', '_self', 1, 2);

-- tablo yapısı dökülüyor pmitln2oq_db0001.subscribe
DROP TABLE IF EXISTS `subscribe`;
CREATE TABLE IF NOT EXISTS `subscribe` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(250) DEFAULT NULL,
  `email` varchar(250) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=utf8;

-- pmitln2oq_db0001.subscribe: ~7 rows (yaklaşık) tablosu için veriler indiriliyor
DELETE FROM `subscribe`;
INSERT INTO `subscribe` (`id`, `name`, `email`) VALUES
	(1, 'Betul', 'b.s.sattari@gmail.com'),
	(2, 'Necati', 'necatiekici911@gmail.com'),
	(3, 'Mehmet', 'mksular@gmail.com'),
	(4, 'özkan', 'ozkanyilmaz@outlook.com.tr'),
	(5, 'nuri', 'nurisahin@gmail.com'),
	(6, 'Ersin', 'ersin@uxyazilim.com'),
	(7, 'Ersin', 'info@seondex.com');

-- tablo yapısı dökülüyor pmitln2oq_db0001.work
DROP TABLE IF EXISTS `work`;
CREATE TABLE IF NOT EXISTS `work` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `title` varchar(250) DEFAULT NULL,
  `subtitle` varchar(500) DEFAULT NULL,
  `detail` longtext,
  `isview` tinyint(1) DEFAULT NULL,
  `date` datetime DEFAULT NULL,
  `like` int(11) DEFAULT NULL,
  `read` int(11) DEFAULT NULL,
  `image` varchar(250) DEFAULT NULL,
  `catid` int(11) DEFAULT NULL,
  `dateend` datetime DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8;

-- pmitln2oq_db0001.work: ~3 rows (yaklaşık) tablosu için veriler indiriliyor
DELETE FROM `work`;
INSERT INTO `work` (`id`, `title`, `subtitle`, `detail`, `isview`, `date`, `like`, `read`, `image`, `catid`, `dateend`) VALUES
	(1, 'Blog başlık', 'blog alt başlık,', 'A small river named Duden flows by their place and supplies it with the necessary', 1, '2023-06-10 10:25:34', 0, 0, 'blog-1.jpg', 5, NULL),
	(2, 'Manchester City - Inter maçı ne zaman, saat kaçta ve hangi kanalda?', 'Şampiyonlar Ligi\'nde 2022-2023 sezonunun şampiyonu, Manchester City ile Inter arasında bu akşam İstanbul\'da oynanacak finalde belli olacak. Manchester City ilk, Inter 4. şampiyonluğunu hedefliyor. Öte yandan Şampiyonlar Ligi kupası tarihte ilk kez bir Türk futbolcunun elinde yükselecek. Peki Manchester City - Inter maçı saat kaçta hangi kanalda? İşte tüm detaylar', 'Şampiyonlar Ligi\'nde 2022-2023 sezonunun şampiyonu, Manchester City ile Inter arasında bu akşam İstanbul\'da oynanacak finalde belli olacak. Manchester City ilk, Inter 4. şampiyonluğunu hedefliyor. Öte yandan Şampiyonlar Ligi kupası tarihte ilk kez bir Türk futbolcunun elinde yükselecek. Peki Manchester City - Inter maçı saat kaçta hangi kanalda? İşte tüm detaylar', 1, '2023-06-10 12:32:13', 5, 176, 'blog-2.jpg', 5, NULL),
	(3, 'dssdfsd', 'sdfsdf', 'sdfdfd', 1, '2023-06-11 10:58:13', 0, 0, 'blog-3.jpg', 5, NULL);

-- tablo yapısı dökülüyor pmitln2oq_db0001.workcat
DROP TABLE IF EXISTS `workcat`;
CREATE TABLE IF NOT EXISTS `workcat` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `title` varchar(250) DEFAULT NULL,
  `subtitle` varchar(500) DEFAULT NULL,
  `detail` longtext,
  `isview` tinyint(1) DEFAULT NULL,
  `image` varchar(250) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=utf8;

-- pmitln2oq_db0001.workcat: ~3 rows (yaklaşık) tablosu için veriler indiriliyor
DELETE FROM `workcat`;
INSERT INTO `workcat` (`id`, `title`, `subtitle`, `detail`, `isview`, `image`) VALUES
	(4, 'Tuval İşleri', NULL, NULL, 1, 'blog-1.jpg'),
	(5, 'Grafiti İşleri', NULL, NULL, 1, 'blog-2.jpg'),
	(6, 'Tattoo İşleri', NULL, NULL, 1, 'blog-3.jpg');

/*!40103 SET TIME_ZONE=IFNULL(@OLD_TIME_ZONE, 'system') */;
/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IFNULL(@OLD_FOREIGN_KEY_CHECKS, 1) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40111 SET SQL_NOTES=IFNULL(@OLD_SQL_NOTES, 1) */;
