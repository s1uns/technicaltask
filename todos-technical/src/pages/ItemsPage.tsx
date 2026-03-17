import React, { useEffect, useState } from "react";
import styled from "@emotion/styled";
import { TaskInput, TaskItem } from "../components";
import { TodoItem } from "../types/TodoItem";
import { getTasks } from "../api/tasks";

const ItemsPage = () => {
	const [items, setItems] = useState<TodoItem[]>([]);

	useEffect(() => {
		const fetchAndSet = async () => {
			const items = await getTasks();
			setItems(items);
		};

		fetchAndSet();
	}, []);

	return (
		<PageContainer>
			<TaskInput setItems={setItems} />
			<ItemsListContainer>
				{items.map((item) => (
					<TaskItem
						id={item.id}
						isCompleted={item.isCompleted}
						text={item.text}
						setItems={setItems}
					/>
				))}
			</ItemsListContainer>
		</PageContainer>
	);
};

export default ItemsPage;

const PageContainer = styled.div`
	width: 100%;
	height: 100vh;
	display: flex;
	flex-direction: column;
	justify-content: center;
	align-items: center;
	gap: 10px;
`;

const ItemsListContainer = styled.div`
	padding: 15px;
	width: 100%;
	margin-top: 10px;
	display: flex;
	flex-direction: column;
	justify-content: flex-start;
	align-items: center;
`;
