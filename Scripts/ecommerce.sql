SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";

CREATE SCHEMA `Ecommerce`;

CREATE TABLE `brand` (
  `Id` int(11) NOT NULL,
  `Name` varchar(45) DEFAULT NULL,
  `Description` varchar(50) DEFAULT NULL,
  `IsDeleted` tinyint(1) NOT NULL DEFAULT 0,
  `CreatedBy` varchar(45) DEFAULT NULL,
  `CreatedDate` datetime DEFAULT NULL,
  `UpdatedBy` varchar(45) DEFAULT NULL,
  `UpdatedDate` datetime DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Volcado de datos para la tabla `brand`
--

INSERT INTO `brand` (`Id`, `Name`, `Description`, `IsDeleted`, `CreatedBy`, `CreatedDate`, `UpdatedBy`, `UpdatedDate`) VALUES
(1, 'BRAND 1.1', 'BRAND 1.1', 0, '', '2022-11-20 16:31:07', 'ME 1.1', '2022-11-20 16:43:46'),
(2, 'BRAND 2', 'BRAND 2', 0, '', '2022-11-20 16:32:35', '0', '2022-11-20 16:32:35'),
(3, 'BRAND 2', 'BRAND 3', 0, '', '2022-11-20 16:32:43', '0', '2022-11-20 16:32:43'),
(4, 'BRAND 3', 'BRAND 4', 0, '', '2022-11-20 16:32:48', '0', '2022-11-20 16:32:48'),
(5, 'BRAND TO DELETE', 'DESCRIPTION NONE', 1, NULL, '0001-01-01 00:00:00', NULL, '0001-01-01 00:00:00');

--
-- Índices para tablas volcadas
--

--
-- Indices de la tabla `brand`
--
ALTER TABLE `brand`
  ADD PRIMARY KEY (`Id`);

--
--
-- AUTO_INCREMENT de las tablas volcadas
--

--
-- AUTO_INCREMENT de la tabla `brand`
--
ALTER TABLE `brand`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
