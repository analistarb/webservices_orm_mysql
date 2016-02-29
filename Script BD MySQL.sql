
SET FOREIGN_KEY_CHECKS=0;

-- ----------------------------
-- Table structure for `produto`
-- ----------------------------
DROP TABLE IF EXISTS `produto`;
CREATE TABLE `produto` (
  `ProdutoId` int(11) NOT NULL,
  `Descricao` varchar(50) default NULL,
  `ProdutoCategoriaId` int(11) default NULL,
  `DataCadastro` datetime default NULL,
  PRIMARY KEY  (`ProdutoId`),
  KEY `FK_Produto_ProdutoCategoria` (`ProdutoCategoriaId`),
  CONSTRAINT `FK_Produto_ProdutoCategoria` FOREIGN KEY (`ProdutoCategoriaId`) REFERENCES `produtocategoria` (`ProdutoCategoriaId`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of produto
-- ----------------------------
INSERT INTO `produto` VALUES ('1', 'DELL VOSTRO', '1', '2016-01-24 14:26:55');
INSERT INTO `produto` VALUES ('2', 'HP ENVY', '1', '2016-01-24 14:26:55');
INSERT INTO `produto` VALUES ('3', 'MICROSOFT', '2', '2016-01-24 14:26:55');
INSERT INTO `produto` VALUES ('4', 'LOGITEC', '2', '2016-01-24 14:26:55');
INSERT INTO `produto` VALUES ('5', 'HP OFFICEJET', '3', '2016-01-24 14:26:55');
INSERT INTO `produto` VALUES ('6', 'HP LASERJET', '3', '2016-01-24 14:26:55');
INSERT INTO `produto` VALUES ('7', 'teste produto', '1', '2016-02-29 11:19:09');

-- ----------------------------
-- Table structure for `produtocategoria`
-- ----------------------------
DROP TABLE IF EXISTS `produtocategoria`;
CREATE TABLE `produtocategoria` (
  `ProdutoCategoriaId` int(11) NOT NULL,
  `Descricao` varchar(50) default NULL,
  PRIMARY KEY  (`ProdutoCategoriaId`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of produtocategoria
-- ----------------------------
INSERT INTO `produtocategoria` VALUES ('1', 'NOTEBOOKS');
INSERT INTO `produtocategoria` VALUES ('2', 'TECLADOS');
INSERT INTO `produtocategoria` VALUES ('3', 'IMPRESSORAS');
INSERT INTO `produtocategoria` VALUES ('4', 'asdsad');

-- ----------------------------
-- Procedure structure for `uspConsultarProduto`
-- ----------------------------
DROP PROCEDURE IF EXISTS `uspConsultarProduto`;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `uspConsultarProduto`(IN INintProdutoID int,IN INvchDescricao varchar(50),IN INintProdutoCategoriaID int)
BEGIN

SELECT 
Pro.ProdutoId,
Pro.Descricao AS DescProduto,
Pro.DataCadastro,
Pro.ProdutoCategoriaId,
ProCat.Descricao AS DescProdutoCategoria
FROM
Produto AS Pro
JOIN
ProdutoCategoria AS ProCat ON (Pro.ProdutoCategoriaId = ProCat.ProdutoCategoriaId)
WHERE
((Pro.ProdutoId = @INintProdutoID) OR (@INintProdutoID IS NULL)) AND
((Pro.Descricao LIKE ('%' + @INvchDescricao + '%')) OR (@INvchDescricao IS NULL)) AND
((Pro.ProdutoCategoriaId = @INintProdutoCategoriaID) OR (@INintProdutoCategoriaID IS NULL))
ORDER BY
Pro.Descricao;

END
;;
DELIMITER ;
