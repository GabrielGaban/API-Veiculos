-- Query para listar todos os veículos
SELECT * FROM Veiculos;

-- Query para inserir um veículo
INSERT INTO Veiculos (Marca, Modelo, Ano, Preco) VALUES (@Marca, @Modelo, @Ano, @Preco);

-- Query para atualizar um veículo
UPDATE Veiculos SET Marca = @Marca, Modelo = @Modelo, Ano = @Ano, Preco = @Preco WHERE Id = @Id;

-- Query para deletar um veículo
DELETE FROM Veiculos WHERE Id = @Id;
